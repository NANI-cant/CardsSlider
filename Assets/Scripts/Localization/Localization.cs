using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class Localization {
    [SerializeField] private TextAsset _localizationXML;

    public UnityAction LanguageChanged;

    private Dictionary<string, List<string>> _localizationMap;
    private int _selectedLanguage;
    private GameSettings _gameSettings;

    public Localization(TextAsset localizationXML, GameSettings gameSettings) {
        _gameSettings = gameSettings;
        _localizationXML = localizationXML;

        InitializeMap();
    }

    private void InitializeMap() {
        if (_localizationMap == null) {
            _selectedLanguage = _gameSettings.SelectedLanguage;
        }

        _localizationMap = new Dictionary<string, List<string>>();

        XmlDocument xml = new XmlDocument();
        xml.LoadXml(_localizationXML.text);

        foreach (XmlNode key in xml["Keys"].ChildNodes) {
            string keyName = key.Attributes["Name"].Value;

            List<string> translations = new List<string>();
            foreach (XmlNode translate in key["Translates"].ChildNodes) {
                translations.Add(translate.InnerText);
            }
            _localizationMap[keyName] = translations;
        }
    }

    public void ChangeLanguage(int language) {
        _selectedLanguage = language;
        _gameSettings.SelectedLanguage = language;
        LanguageChanged?.Invoke();
    }

    public string GetLocalizedText(string key) {
        if (_localizationMap.ContainsKey(key)) {
            return _localizationMap[key][(_selectedLanguage)];
        }
        else {
            return "No Definition for key: " + key;
        }
    }
}
