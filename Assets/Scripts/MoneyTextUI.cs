using UnityEngine;
using TMPro;

public class MoneyTextUI : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;

    public void UpdateMoney(int MoneyValue)
    {
        if (MoneyText == null) return;

        MoneyText.text = "Money: " + MoneyValue;
    }
}