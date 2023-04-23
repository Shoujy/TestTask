using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterInventory _characterInventory;
    private MoneyBag _moneyBag;

    public MoneyBag MoneyBag => _moneyBag;

    private void Awake()
    {
        _characterInventory = new CharacterInventory();
        _moneyBag = new MoneyBag();
    }

    private void Start()
    {
        _moneyBag.AddCurrency(new Gold(1000));
    }

    public void AddItemToInventory(ItemData item)
    {
        _characterInventory.AddItem(item);
    }

    public void RemoveItemFromInventory(ItemData item)
    {
        _characterInventory.RemoveItem(item);
    }

    public bool CheckItem(ItemData item)
    {
        return _characterInventory.Items.Contains(item);
    }

    public void AddCurrencyToBag(Currency currency)
    {
        _moneyBag.AddCurrency(currency);
    }

    public void RemoveCurrencyFromBag(Currency currency)
    {
        _moneyBag.RemoveCurrency(currency);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.EndInteraction();
        }
    }
}
