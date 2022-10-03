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
        _localization.LanguageChanged += ChangeLanguage;
    }

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        ChangeLanguage();
    }

    private void OnDestroy() {
        _localization.LanguageChanged -= ChangeLanguage;
    }

    public void SetKey(string key) {
        _localizationKey = key;
        ChangeLanguage();
    }

    private void ChangeLanguage() {
        if (_localization == null) return;
        GetComponent<TextMeshProUGUI>().text = _localization.GetLocalizedText(_localizationKey);
    }
}
