using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler
{
    public Button button;
    public Text nameLabel;
    public Image icon;
    public GameObject popupPrefab;


    private Item item;
    private InventoryScrollList scrollList;
    private bool popupCreated = false;
    private ItemPopup itemInfo;
    private Transform popupSpawn;
    private GameObject instantiatedPopup;

    public void Setup(Item currentItem, InventoryScrollList currentScrollList, Transform popupSpawn)
    {
        this.item = currentItem;
        this.nameLabel.text = this.item.title;
        this.icon.sprite = this.item.icon;

        this.scrollList = currentScrollList;
        this.popupSpawn = popupSpawn;
    }

    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherShop(this.item);
        if (this.popupCreated)
            Destroy(this.instantiatedPopup);
        popupCreated = false;
        Debug.Log(this.popupCreated);

    }
    // Start is called before the first frame update
    void Start()
    {
        this.button.onClick.AddListener(HandleClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!this.popupCreated)
        {
            this.instantiatedPopup = Instantiate(popupPrefab, this.popupSpawn.transform);
            this.popupCreated = true;

            ItemPopup itemInfo = this.instantiatedPopup.GetComponent<ItemPopup>();
            this.itemInfo = itemInfo;
            itemInfo.description.text = this.item.description;
            itemInfo.item = this.item;

            if (!this.item.beenPurchased)
            {
                itemInfo.equipButton.interactable = false;
            }
        }
    }

}
