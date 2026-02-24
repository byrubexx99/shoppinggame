using UnityEngine;

public enum Language { English = 0, Spanish = 1, Catalan = 2 }

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;
    public Language currentLanguage = Language.English;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void ChangeLanguage(int index)
    {
        currentLanguage = (Language)index;
        Debug.Log("Idioma cambiado a: " + currentLanguage);
        
        if (InventoryUIManager.Instance != null)
        {
            InventoryUIManager.Instance.UpdateInfoBox();
        }

        LocalizedTextUI[] allTexts = FindObjectsByType<LocalizedTextUI>(FindObjectsSortMode.None);
        foreach (LocalizedTextUI text in allTexts)
        {
            text.ActualizarTexto();
        }
        MoneyTextUI[] moneyTexts = FindObjectsByType<MoneyTextUI>(FindObjectsSortMode.None);
        foreach (MoneyTextUI moneyText in moneyTexts)
        {
            moneyText.ActualizarTexto();
        }   
    }
}