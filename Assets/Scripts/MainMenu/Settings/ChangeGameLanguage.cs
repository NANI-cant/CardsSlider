using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMPro.TMP_Dropdown))]
public class ChangeGameLanguage : MonoBehaviour
{
    private TMPro.TMP_Dropdown _dropdownList;
    private GameSettings _gameSettings;
    private Localization _localization;
 
    [Inject]
    public void Construct(GameSettings gameSettings, Localization localization){
        _gameSettings = gameSettings;
        _localization = localization;
    }

    private void Awake(){
        _dropdownList = GetComponent<TMPro.TMP_Dropdown>(); 
        _dropdownList.value = _gameSettings.SelectedLanguage;
    }

    private void OnEnable(){
        _dropdownList.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDisable(){
        _dropdownList.onValueChanged.RemoveListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int value){
        Debug.Log("OnDropdownValueChanged: "+ value);
        _localization.ChangeLanguage(value);
    }
}
