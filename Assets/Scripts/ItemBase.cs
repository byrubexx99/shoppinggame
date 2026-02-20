using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Items/Generic")]
public class ItemBase : ScriptableObject
{
    public string Name;
    public int Price = 20;
    public Sprite ImageUI;
    public bool IsStackable;
}