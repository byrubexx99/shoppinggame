using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISlotInventory : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public Image selectionBorder;
    public ItemBase Item { get; private set; }
    public int Index { get; private set; }
    public Inventory OwnerInventory { get; private set; }

    public void Setup(Inventory owner, int index)
    {
        OwnerInventory = owner;
        Index = index;
        SetItem(null);
    }

    public void SetItem(ItemBase item)
    {
        Item = item;

        if (icon == null)
        {
            Debug.LogWarning("Icon no asignado en slot " + Index);
            return;
        }

        if (item != null)
        {
            Debug.Log("Slot " + Index + " muestra: " + item.Name);
            icon.sprite = item.ImageUI;
            icon.enabled = true;
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Item != null)
        {
            Debug.Log("Seleccionado: " + Item.Name);
            InventoryUIManager.Instance.SelectSlot(this);
        }
    }

    public void SetSelected(bool value)
    {
        if (selectionBorder != null) selectionBorder.enabled = value;
    }
}