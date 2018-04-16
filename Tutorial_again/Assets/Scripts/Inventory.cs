using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance
    {
        get;
        private set;
    }

    private JSONObject itemsData;
    public static int SelectedItemIndex
    {
        get;
        private set;
    }


    public class ShopItem
    {
        public bool Bought, Selected;
        public string Name;
        public int Price;

        public ShopItem(bool bought, bool selected, int price, string name)
        {
            Bought = bought;
            Selected = selected;
            Price = price;
            Name = name;
        }
    }

    public static List<ShopItem> Items;
    public static int Currency
    {
        get;
        private set;
    }

    public void Awake()
    {
        Instance = this;

        // THIS IS WHERE I WANT HERE  //
        if (!PlayerPrefs.HasKey("Items"))
            {
            PlayerPrefs.SetString("Items", "{\"Items\":[{\"name\":\"Fire Rate\",\"bought\":false,\"selected\":false,\"price\":100},{\"name\":\"Move Speed\",\"bought\":false,\"selected\":false,\"price\":500},{\"name\":\"Hardened Bullets\",\"bought\":false,\"selected\":false,\"price\":1000}]}");
            PlayerPrefs.SetInt("Currency", 10000);
            }
        Currency = PlayerPrefs.GetInt("Currency");

        //where i store the parsed data aka the user data
        itemsData = JSONObject.Parse(PlayerPrefs.GetString("Items"));

        Items = new List<ShopItem>();

        for (int i =0; i< itemsData.GetArray("Items").Length ; i++)
        {
            Items.Add(new ShopItem(itemsData.GetArray("Items")[i].Obj.GetBoolean("bought"), itemsData.GetArray("Items")[i].Obj.GetBoolean("selected"),
                (int)itemsData.GetArray("Items")[i].Obj.GetNumber("price"),
                itemsData.GetArray("Items")[i].Obj.GetString("name")));

            if(Items[i].Selected)
            {
                SelectedItemIndex = i;
            }

        }
    }

    public void SelectItem(int index)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Selected)
            {
                Items[i].Selected = false;
                itemsData.GetArray("Items")[i].Obj.GetValue("selected").Boolean = false;
            }
        }

        Items[index].Selected = true;
        itemsData.GetArray("Items")[index].Obj.GetValue("selected").Boolean = true;

        SelectedItemIndex = index;

        // I am doing this to put all of the information from the user into a JSON String to then be parsed as info to update
        PlayerPrefs.SetString("Items", itemsData.ToString());

        // Instead this is where I would put my updates for thr user

      //  if()
          //  PlayerPrefs.DeleteAll();

      PlayerPrefs.Save();

    }

    public void BuyItem(int index)
    {
        if (SubtractCurrency(Items[index].Price))
        {
            Items[index].Bought = true;
            itemsData.GetArray("Items")[index].Obj.GetValue("bought").Boolean = true;
            SelectItem(index);
        }
    }

    private bool SubtractCurrency(int value)
    {
        if (Currency - value < 0)
            return false;
        Currency -= value;

        PlayerPrefs.SetInt("Currency", Currency);
        return true;
    }

}
