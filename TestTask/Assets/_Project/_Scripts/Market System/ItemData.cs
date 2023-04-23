using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "MarketSystem/Item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public int Price;
    public Sprite ItemIcon;
}