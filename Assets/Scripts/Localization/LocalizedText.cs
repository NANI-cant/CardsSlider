using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour {
    [SerializeField] private string _localizationKey;

    private Localization _localization;

    private TextMeshProUGUI _uGUI;

    [Inject]
    public void Construct(Localization localization) {
        _localization = localization;
    }

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
        ChangeLanguage();
    }

    private void OnEnable() {
        _localization.OnLanguageChange += ChangeLanguage;
    }

    private void OnDisable() {
        _localization.OnLanguageChange -= ChangeLanguage;
    }

    public void SetKey(string key) {
        _localizationKey = key;
        ChangeLanguage();
    }

    private void ChangeLanguage() {
        GetComponent<TextMeshProUGUI>().text = _localization.GetLocalizedText(_localizationKey);
    }
}
