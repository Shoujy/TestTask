using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory
{
    private List<ItemData> _items;
    public List<ItemData> Items => _items;

    public CharacterInventory()
    {
        _items= new List<ItemData>();
    }

    public void AddItem(ItemData item)
    {
        _items.Add(item);
    }

    public void RemoveItem(ItemData item)
    {
        if(_items.Contains(item))
        {
            _items.Remove(item);
        }
        else
        {
            Debug.Log($"Item [{item.Name}] does not exist");
        }
    }
}
