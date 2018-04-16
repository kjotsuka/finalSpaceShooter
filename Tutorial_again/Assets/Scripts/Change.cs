using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public Text CurrencyText;//, SelectedItemText;
    /*
    ///  public static Inventory Instance
     /// {
      //    get;
       //   private set;
     // }

      public static Change Instance
      {
          get;
          private set;
      }

      public class ShopItem
      {
          public bool Bought, Selected;
          public string Name;
          public int Price;
          //
          public int UpgradeLevels;

          public ShopItem(bool bought, bool selected, int price, string name) //,int upgradeLevels)
          {
              Bought = bought;
              Selected = selected;
              Price = price;
              Name = name;

              // might be an ENUM later on for when we keep track 
            //  UpgradeLevels = upgradeLevels;
          }
      }

      public class User
      {
          public string Name;
          public int Level;

          public User(int level, string name)
          {
              Name = name;
              Level = level;
          }

      }

      public static List<ShopItem> Items;

      public static int Currency
      {
          get;

          private set;
      }




      // Use this for initialization
      public void Awake()
      {
          Items = new List<ShopItem>();

          //for (int i = 0; i < 4; i++)
        //  { 
              Items.Add(new ShopItem(false, false,
                 1000,
                 "Fire Rate"));

              Items.Add(new ShopItem(true, true,
                 1000,
                 "Move Speed"));
          // }


          PlayerPrefs.SetInt("Currency", 10000);
      }

      // Update is called once per frame
      private void UpdateUI (int index)
      {
          CurrencyText.text = "Currency:" + Change.User.Name.ToString();


      }

      */
    public static Change Instance
    {
        get;
        private set;
    }


    public static int Currency
    {
        get;

        private set;
    }

    public void Awake()
    {
     //   Instance = this;

        // THIS IS WHERE I WANT HERE  //
      //  if (!PlayerPrefs.HasKey("Items"))
     //   {
           // PlayerPrefs.SetString("Items", "{\"Items\":[{\"name\":\"Fire Rate\",\"bought\":false,\"selected\":false,\"price\":100},{\"name\":\"Move Speed\",\"bought\":false,\"selected\":false,\"price\":500},{\"name\":\"Hardened Bullets\",\"bought\":false,\"selected\":false,\"price\":1000}]}");
          //  PlayerPrefs.SetInt("Currency", 10000);
       PlayerPrefs.SetInt("Price", 4445);

        ////hmmmmmmmmmmmm//
       bool bought = PlayerPrefs.HasKey("Bought");
        //   }
        //   PlayerPrefs.GetInt("Currency");

        //where i store the parsed data aka the user data



        CurrencyText.text = "Currency:" + (PlayerPrefs.GetInt("Currency").ToString());

        if (SubtractCurrency(PlayerPrefs.GetInt("Price")))
        {
            bought = true;
            
        }


    }


    public class User
    {
        public string Name;
        public int Level;
        public int Currency;

        public User(int level, string name, int currency)
        {
            Name = name;
            Level = level;
            Currency = currency;
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



