using UnityEngine;

public class InventoryGridUI : MonoBehaviour
{
    public Inventory Inventory;
    private UISlotInventory[] Slots;

    void Awake()
    {
        Slots = GetComponentsInChildren<UISlotInventory>();

        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].Setup(Inventory, i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (i < Inventory.Items.Count) Slots[i].SetItem(Inventory.Items[i]);
            else Slots[i].SetItem(null);
        }
    }
}