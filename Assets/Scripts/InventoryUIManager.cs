using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager Instance;

    public Inventory PlayerInventory;
    public Inventory ShopInventory;

    public InventoryGridUI PlayerGrid;
    public InventoryGridUI ShopGrid;

    public Button BuyButton;
    public Button SellButton;

    private UISlotInventory SelectedSlot;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshUI();
    }

    public void SelectSlot(UISlotInventory Slot)
    {
        if (SelectedSlot != null) SelectedSlot.SetSelected(false);

        SelectedSlot = Slot;
        SelectedSlot.SetSelected(true);

        UpdateButtons();
    }

    public void BuySelectedItem()
    {
        if (SelectedSlot == null) return;
        if (SelectedSlot.OwnerInventory != ShopInventory) return;
        if (SelectedSlot.Item == null) return;

        ItemBase Item = SelectedSlot.Item;

        if (!PlayerInventory.HasMoney(Item.Price))
        {
            Debug.Log("No hay dinero suficiente");
            return;
        }

        Debug.Log("Comprando: " + Item.Name);

        PlayerInventory.RemoveMoney(Item.Price);
        ShopInventory.AddMoney(Item.Price);

        ShopInventory.RemoveItem(Item);
        PlayerInventory.AddItem(Item);

        ClearSelection();
        RefreshUI();
    }

    public void SellSelectedItem()
    {
        if (SelectedSlot == null) return;
        if (SelectedSlot.OwnerInventory != PlayerInventory) return;
        if (SelectedSlot.Item == null) return;

        ItemBase Item = SelectedSlot.Item;

        Debug.Log("Vendiendo: " + Item.Name);

        PlayerInventory.AddMoney(Item.Price);
        ShopInventory.RemoveMoney(Item.Price);

        PlayerInventory.RemoveItem(Item);
        ShopInventory.AddItem(Item);

        ClearSelection();
        RefreshUI();
    }

    void ClearSelection()
    {
        if (SelectedSlot != null) SelectedSlot.SetSelected(false);

        SelectedSlot = null;
        UpdateButtons();
    }

    void RefreshUI()
    {
        PlayerGrid.Refresh();
        ShopGrid.Refresh();
        UpdateButtons();
    }

    void UpdateButtons()
    {
        if (BuyButton != null)
        {
            BuyButton.interactable = false;
            if (SelectedSlot != null)
            {
                if (SelectedSlot.OwnerInventory == ShopInventory)
                {
                    if (SelectedSlot.Item != null)
                    {
                        BuyButton.interactable = true;
                    }
                }
            }
        }
        if (SellButton != null)
        {
            SellButton.interactable = false;
            if (SelectedSlot != null)
            {
                if (SelectedSlot.OwnerInventory == PlayerInventory)
                {
                    if (SelectedSlot.Item != null)
                    {
                        SellButton.interactable = true;
                    }
                }
            }
        }
    }
}