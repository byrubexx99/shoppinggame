using UnityEngine;
using TMPro;

public class MoneyTextUI : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;
    public string EnglishText = "Money: ";
    public string SpanishText = "Dinero: ";
    public string CatalanText = "Diners: ";
   
    private int currentMoneyAmount = 0; 

    public void UpdateMoney(int MoneyValue)
    {
        currentMoneyAmount = MoneyValue;
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        if (MoneyText == null) return;

        string prefix = EnglishText; 

        if (LocalizationManager.Instance != null)
        {
            switch (LocalizationManager.Instance.currentLanguage)
            {
                case Language.Spanish: prefix = SpanishText; break;
                case Language.Catalan: prefix = CatalanText; break;
                default: prefix = EnglishText; break;
            }
        }
        MoneyText.text = prefix + currentMoneyAmount;
    }
}