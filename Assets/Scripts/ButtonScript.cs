using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public Button buttonComponent;
    public Text nameLabel;
    public Image iconImage;
    //public Text priceText;


    private Item item;
    private ContentListManager scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(Item currentItem, ContentListManager currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.title;
        iconImage.sprite = item.icon;
        //priceText.text = item.price.ToString();
        scrollList = currentScrollList;

    }

    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherShop(item);
    }
}