using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager Instance;

    public Inventory playerInventory;
    public Inventory shopInventory;

    public InventoryGridUI playerGrid;
    public InventoryGridUI shopGrid;

    public Button buyButton;
    public Button sellButton;

    private UISlotInventory selectedSlot;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshUI();
    }

    public void SelectSlot(UISlotInventory slot)
    {
        if (selectedSlot != null)
            selectedSlot.SetSelected(false);

        selectedSlot = slot;
        selectedSlot.SetSelected(true);

        UpdateButtons();
    }

    public void BuySelectedItem()
    {
        if (selectedSlot == null) return;
        if (selectedSlot.OwnerInventory != shopInventory) return;
        if (selectedSlot.Item == null) return;

        ItemBase item = selectedSlot.Item;

        if (!playerInventory.HasMoney(item.Price))
        {
            Debug.Log("No hay dinero suficiente");
            return;
        }

        Debug.Log("Comprando: " + item.Name);

        playerInventory.RemoveMoney(item.Price);
        shopInventory.AddMoney(item.Price);

        shopInventory.RemoveItem(item);
        playerInventory.AddItem(item);

        ClearSelection();
        RefreshUI();
    }

    public void SellSelectedItem()
    {
        if (selectedSlot == null) return;
        if (selectedSlot.OwnerInventory != playerInventory) return;
        if (selectedSlot.Item == null) return;

        ItemBase item = selectedSlot.Item;

        Debug.Log("Vendiendo: " + item.Name);

        playerInventory.AddMoney(item.Price);
        shopInventory.RemoveMoney(item.Price);

        playerInventory.RemoveItem(item);
        shopInventory.AddItem(item);

        ClearSelection();
        RefreshUI();
    }

    void ClearSelection()
    {
        if (selectedSlot != null)
            selectedSlot.SetSelected(false);

        selectedSlot = null;
        UpdateButtons();
    }

    void RefreshUI()
    {
        playerGrid.Refresh();
        shopGrid.Refresh();
        UpdateButtons();
    }

    void UpdateButtons()
    {
        if (buyButton != null)
            buyButton.interactable =
                selectedSlot != null &&
                selectedSlot.OwnerInventory == shopInventory &&
                selectedSlot.Item != null;

        if (sellButton != null)
            sellButton.interactable =
                selectedSlot != null &&
                selectedSlot.OwnerInventory == playerInventory &&
                selectedSlot.Item != null;
    }
}