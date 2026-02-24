using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Items/Generic")]
public class ItemBase : ScriptableObject
{
    [Header("Localization Names")]
    public string NameEnglish;
    public string NameSpanish;
    public string NameCatalan;

    [Header("Localization Descriptions")]
    [TextArea(2, 4)] public string DescriptionEnglish;
    [TextArea(2, 4)] public string DescriptionSpanish;
    [TextArea(2, 4)] public string DescriptionCatalan;

    public string Name 
    {
        get 
        {
            if (LocalizationManager.Instance == null) return NameEnglish;

            switch (LocalizationManager.Instance.currentLanguage)
            {
                case Language.Spanish: return NameSpanish;
                case Language.Catalan: return NameCatalan;
                default: return NameEnglish;
            }
        }
    }

    public string Description 
    {
        get 
        {
            if (LocalizationManager.Instance == null) return DescriptionEnglish;

            switch (LocalizationManager.Instance.currentLanguage)
            {
                case Language.Spanish: return DescriptionSpanish;
                case Language.Catalan: return DescriptionCatalan;
                default: return DescriptionEnglish;
            }
        }
    }

    [Header("Other Data")]
    public int Price = 20;
    public Sprite ImageUI;
    public bool IsStackable;
}