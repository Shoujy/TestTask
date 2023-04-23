using System.Collections.Generic;
using UnityEngine;

public class SlotGeneratorUI : MonoBehaviour
{
    [SerializeField] private ItemSlotUI _itemSlot;
    private List<ItemData> _items;
 
    private void Awake()
    {
        ItemData[] loadedItems = Resources.LoadAll<ItemData>("Swords");
        _items = new List<ItemData>(loadedItems);
    }

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            var generatedSlot = Instantiate(_itemSlot, transform);
            generatedSlot.Setup(_items[i]);
        }
    }
}
