using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SwordSeller : MonoBehaviour, ISeller, IInteractable
{
    [SerializeField] private GameObject _sellPanel;
    [SerializeField] private CinemachineVirtualCamera _sellCamera;

    private List<ItemData> _swords;

    public static Action<string> OnSellerNotificationTriggered;
    
    private void Start()
    {
        _sellPanel.SetActive(false);
        LoadItems();
    }

    private void LoadItems()
    {
        ItemData[] loadedItems = Resources.LoadAll<ItemData>("Swords");
        _swords = new List<ItemData>(loadedItems);
    }

    public void SellItem(ItemData item, Character character)
    {
        if(_swords.Contains(item))
        {
            if(character.MoneyBag.CanAfford(new Gold(item.Price), item.Price))
            {
                character.MoneyBag.RemoveCurrency(new Gold(item.Price));
                character.AddItemToInventory(item);

                OnSellerNotificationTriggered?.Invoke($"You buy new [{item.Name}] for {item.Price} Gold");
            }
            else
            {
                OnSellerNotificationTriggered?.Invoke($"You can't afford it!");
            }
        }
        else
        {
            OnSellerNotificationTriggered?.Invoke($"[{item.Name}] sword do not exist!");
        }
    }

    public void Interact(Character character)
    {
        _sellPanel.SetActive(true);
        _sellCamera.Priority = 15;
        Debug.Log("This is Seller interaction Started");
    }

    public void EndInteraction()
    {
        _sellPanel.SetActive(false);
        _sellCamera.Priority = 1;
        Debug.Log("This is Seller interaction Ended");
    }
}
