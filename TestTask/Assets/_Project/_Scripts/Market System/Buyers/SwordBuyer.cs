using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SwordBuyer : MonoBehaviour, IBuyer, IInteractable
{
    [SerializeField] private GameObject _buyPanel;
    [SerializeField] private CinemachineVirtualCamera _buyCamera;
    
    private List<ItemData> _swords;

    public static Action<string> OnBuyerNotificationTriggered;

    private void Start()
    {
        _buyPanel.SetActive(false);
        LoadItems();
    }

    private void LoadItems()
    {
        ItemData[] loadedItems = Resources.LoadAll<ItemData>("Swords");
        _swords = new List<ItemData>(loadedItems);
    }

    public void BuyItem(ItemData item, Character character)
    {
        if (_swords.Contains(item))
        {
            if (character.CheckItem(item))
            {
                character.MoneyBag.AddCurrency(new Gold(item.Price));
                character.RemoveItemFromInventory(item);

                OnBuyerNotificationTriggered?.Invoke($"You sell your [{item.Name}] for {item.Price} Gold");
            }
            else
            {
                OnBuyerNotificationTriggered?.Invoke($"You do not have [{item.Name}] for selling");
            }
        }
        else
        {
            OnBuyerNotificationTriggered?.Invoke($"[{item.Name}] sword do now exist for sellin!");
        }
    }

    public void Interact(Character character)
    {
        Debug.Log("This is Buyer interaction Started");

        _buyCamera.Priority = 15;
        _buyPanel.SetActive(true);
    }

    public void EndInteraction()
    {
        Debug.Log("This is Buyer interaction Ended");

        _buyCamera.Priority = 1;
        _buyPanel.SetActive(false);
    }
}
