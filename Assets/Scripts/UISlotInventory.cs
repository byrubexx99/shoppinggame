using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISlotInventory : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    public Image Icon;
    public Image SelectionBorder;

    public ItemBase Item { get; private set; }
    public int Index { get; private set; }
    public Inventory OwnerInventory { get; private set; }
    public int SlotIndex;

    public void Setup(Inventory Owner, int IndexValue)
    {
        OwnerInventory = Owner;
        Index = IndexValue;
        SetItem(null);
    }

    public void SetItem(ItemBase NewItem)
    {
        Item = NewItem;

        if (Icon == null)
        {
            Debug.LogWarning("Icon no asignado en slot " + Index);
            return;
        }
        if (NewItem != null)
        {
            Debug.Log("Slot " + Index + " muestra: " + NewItem.Name);
            Icon.sprite = NewItem.ImageUI;
            Icon.enabled = true;
        }
        else
        {
            Icon.sprite = null;
            Icon.enabled = false;
            SetSelected(false);
        }
    }

    public void OnPointerClick(PointerEventData EventData)
    {
        if (Item != null)
        {
            Debug.Log("Seleccionado: " + Item.Name);
            InventoryUIManager.Instance.SelectSlot(this);
        }
    }

    public void SetSelected(bool Value)
    {
        if (SelectionBorder != null) SelectionBorder.enabled = Value;
    }

    public void OnDrop(PointerEventData EventData)
    {
        GameObject DraggedObject = EventData.pointerDrag;
        UIDragItem DragItem = DraggedObject.GetComponent<UIDragItem>();

        if (DragItem != null) DragItem.ParentAfterDrag = transform;
    }
}