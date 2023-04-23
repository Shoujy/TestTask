using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemPrice;

    private ItemData _item;

    public void Setup(ItemData itemToSell)
    {
        _item = itemToSell;

        _itemIcon.sprite = _item.ItemIcon;
        _itemName.SetText(_item.Name);
        _itemPrice.SetText("Price: " + _item.Price.ToString());
    }

    public void SellItem()
    {
        SwordSeller seller = FindObjectOfType<SwordSeller>();
        Character character = FindObjectOfType<Character>();

        seller.SellItem(_item, character);
    }

    public void BuyItem()
    {
        SwordBuyer buyer = FindObjectOfType<SwordBuyer>();
        Character character = FindObjectOfType<Character>();

        buyer.BuyItem(_item, character);
    }
}
