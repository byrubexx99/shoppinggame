using UnityEngine;
using TMPro; 

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedTextUI : MonoBehaviour
{
    public string EnglishText;
    public string SpanishText;
    public string CatalanText;

    private TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        if (LocalizationManager.Instance == null || _textComponent == null) return;

        switch (LocalizationManager.Instance.currentLanguage)
        {
            case Language.Spanish: _textComponent.text = SpanishText; break;
            case Language.Catalan: _textComponent.text = CatalanText; break;
            default: _textComponent.text = EnglishText; break;
        }
    }
}