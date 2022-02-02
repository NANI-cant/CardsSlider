using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour {
    [SerializeField] private string _localizationKey;

    private TextMeshProUGUI _uGUI;

    public TextMeshProUGUI UGUI => _uGUI;

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
        ChangeLanguage();
    }

    private void OnEnable() {
        LocalizationManager.OnLanguageChange += ChangeLanguage;
    }

    private void OnDisable() {
        LocalizationManager.OnLanguageChange -= ChangeLanguage;
    }

    public void SetKey(string key){
        _localizationKey = key;
        ChangeLanguage();
    }

    private void ChangeLanguage() {
        GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetLocalizedText(_localizationKey);
    }
}
