using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class InventoryScrollList : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public InventoryScrollList otherShop;
    public SimpleObjectPool objectPool;
    public Transform popupSpawn;

    private ItemDatabase db = new ItemDatabase();

    public void TryTransferItemToOtherShop(Item item)
    {
        if (!item.beenPurchased)
        {
            this.AddItem(item, otherShop);
            this.RemoveItem(item, this);

            RefreshDisplay();
            otherShop.RefreshDisplay();
            item.beenPurchased = true;
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        this.RefreshDisplay();
    }


    public void RefreshDisplay()
    {
        this.RemoveButtons();
        this.AddButtons();
    }

    private void AddButtons()
    {
        for(int i =0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = objectPool.GetObject();
            newButton.transform.SetParent(this.contentPanel);

            ButtonScript button = newButton.GetComponent<ButtonScript>();
            button.Setup(item, this, this.popupSpawn);
        }
    }

    private void RemoveButtons()
    {
        while(this.contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            objectPool.ReturnObject(toRemove);
        }
    }

    private void AddItem(Item itemToAdd, InventoryScrollList invetoryList)
    {
        invetoryList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, InventoryScrollList inventory)
    {
        for (int i = inventory.itemList.Count - 1; i >= 0; i--)
        {
            if (inventory.itemList[i] == itemToRemove)
                inventory.itemList.RemoveAt(i);
        }
    }
}
