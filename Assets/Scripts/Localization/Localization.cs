using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class Localization : MonoBehaviour {
    [SerializeField] private TextAsset _localizationXML;

    private Dictionary<string, List<string>> _localizationMap;

    public int SelectedLanguage;
    public UnityAction OnLanguageChange;

    public void Initialize() {
        if (_localizationMap == null) {
            SelectedLanguage = PlayerPrefs.GetInt(SaveKey.Language, 0);
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

    public string GetLocalizedText(string key) {
        if (_localizationMap.ContainsKey(key)) {
            return _localizationMap[key][(SelectedLanguage)];
        }
        else {
            return "No Definition for key: " + key;
        }
    }

    [ContextMenu("Change Language")]
    public void DebugChangeLanguage() {
        if (SelectedLanguage == 0) {
            SelectedLanguage = 1;
        }
        else {
            SelectedLanguage = 0;
        }
        PlayerPrefs.SetInt(SaveKey.Language, SelectedLanguage);
        OnLanguageChange?.Invoke();
    }
}
