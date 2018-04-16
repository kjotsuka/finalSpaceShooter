using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] shopButtons;

    public Text CurrencyText, SelectedItemText;
    public Color SelectedColor, NonSelectedColor;

    private int prevSelectedIndex;

    private void Start()
    {
        // gets names from json string
        for(int i = 0; i < shopButtons.Length ; i++)
        {
            shopButtons[i].GetChild(0).GetComponent<Text>().text = Inventory.Items[i].Name;
        }

        UpdateUI(Inventory.SelectedItemIndex);

    }

    public void BuyOrSelectItem(int index)
    {
        if (Inventory.Items[index].Bought)
        {
            Inventory.Instance.SelectItem(index);
            UpdateUI(index);
        }
        else
        {
            Inventory.Instance.BuyItem(index);
            UpdateUI(index);
        }
    }

    // I can do wonky animations here instaed from the GUI aspec of UNITY 
    private void UpdateUI(int index)
    {
        CurrencyText.text = "Currency:" + Inventory.Currency.ToString();
        SelectedItemText.text = Inventory.Items[Inventory.SelectedItemIndex].Name;

        shopButtons[prevSelectedIndex].GetComponent<Image>().color = NonSelectedColor;
        shopButtons[Inventory.SelectedItemIndex].GetComponent<Image>().color = SelectedColor;

        prevSelectedIndex = Inventory.SelectedItemIndex;
    }


}
