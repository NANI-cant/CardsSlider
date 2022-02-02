using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class LocalizationManager : MonoBehaviour {
    [SerializeField] private TextAsset _localizationXML;

    private static Dictionary<string, List<string>> _localizationMap;

    public static int SelectedLanguage;
    public static UnityAction OnLanguageChange;

    private void Awake() {
        SelectedLanguage = PlayerPrefs.GetInt(SaveKey.Language, 0);
        if (_localizationMap == null) {
            Initialize();
        }
    }

    private void Initialize() {
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

    public static string GetLocalizedText(string key) {
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
        PlayerPrefs.SetInt(SaveKey.Language,SelectedLanguage);
        OnLanguageChange?.Invoke();
    }
}
