using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour {
    [SerializeField] private string _localizationKey;

    [Inject] private Localization _localization;

    private TextMeshProUGUI _uGUI;

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
