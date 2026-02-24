using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager Instance;

    public Inventory PlayerInventory;
    public Inventory ShopInventory;

    public InventoryGridUI PlayerGrid;
    public InventoryGridUI ShopGrid;

    public Button BuyButton;
    public Button SellButton;

    [Header("Caja de Información del Ítem")]
    public TextMeshProUGUI ItemNameText;        
    public TextMeshProUGUI ItemDescriptionText; 
    public TextMeshProUGUI ItemPriceText;       

    private UISlotInventory SelectedSlot;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshUI();
        ClearInfoBox();
    }

    public void SelectSlot(UISlotInventory Slot)
    {
        if (SelectedSlot != null) SelectedSlot.SetSelected(false);

        SelectedSlot = Slot;
        SelectedSlot.SetSelected(true);

        UpdateButtons();
        UpdateInfoBox(); 
    }

    public void UpdateInfoBox()
    {
        if (SelectedSlot != null && SelectedSlot.Item != null)
        {
            string lblName = "Name:";
            string lblDesc = "Description:";
            string lblPrice = "Price:";

            if (LocalizationManager.Instance != null)
            {
                switch (LocalizationManager.Instance.currentLanguage)
                {
                    case Language.Spanish:
                        lblName = "Nombre:";
                        lblDesc = "Descripción:";
                        lblPrice = "Precio:";
                        break;
                    case Language.Catalan:
                        lblName = "Nom:";
                        lblDesc = "Descripció:";
                        lblPrice = "Preu:";
                        break;
                }
            }

            if (ItemNameText != null) 
            {
                ItemNameText.text = $"<color=yellow><b>{lblName}</b></color> {SelectedSlot.Item.Name}";
            }

            if (ItemDescriptionText != null) 
            {
                ItemDescriptionText.text = $"<color=yellow><b>{lblDesc}</b></color> {SelectedSlot.Item.Description}";
            }
            
            if (ItemPriceText != null) 
            {
                ItemPriceText.text = $"<color=yellow><b>{lblPrice}</b></color> {SelectedSlot.Item.Price}"; 
            }
        }
        else
        {
            ClearInfoBox();
        }
    }

    void ClearInfoBox()
    {
        if (ItemNameText != null) ItemNameText.text = "";
        if (ItemDescriptionText != null) ItemDescriptionText.text = "";
        if (ItemPriceText != null) ItemPriceText.text = ""; 
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
        ClearInfoBox();
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