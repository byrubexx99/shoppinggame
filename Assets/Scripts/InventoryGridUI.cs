using UnityEngine;

public class InventoryGridUI : MonoBehaviour
{
    public Inventory inventory;
    private UISlotInventory[] slots;

    void Awake()
    {
        slots = GetComponentsInChildren<UISlotInventory>();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Setup(inventory, i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
                slots[i].SetItem(inventory.items[i]);
            else
                slots[i].SetItem(null);
        }
    }
}