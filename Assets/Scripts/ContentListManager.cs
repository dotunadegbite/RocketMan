using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ContentListManager : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public ContentListManager otherShop;
    //public Text myGoldDisplay;
    public ObjectPool buttonObjectPool;

    public float gold = 20f;


    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
    }

    void RefreshDisplay()
    {
        //myGoldDisplay.text = "Gold: " + gold.ToString();
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            ButtonScript sampleButton = newButton.GetComponent<ButtonScript>();
            sampleButton.Setup(item, this);
        }
    }

    public void TryTransferItemToOtherShop(Item item)
    {
        /**
         * Commented out becuase Items currently have no price
         */
        //if (otherShop.gold >= item.price)
        //{
        //    gold += item.price;
        //    otherShop.gold -= item.price;

        //    AddItem(item, otherShop);
        //    RemoveItem(item, this);

        //    RefreshDisplay();
        //    otherShop.RefreshDisplay();
        //    Debug.Log("enough gold");

        //}
        Debug.Log("attempted");
    }

    void AddItem(Item itemToAdd, ContentListManager shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ContentListManager shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }
}