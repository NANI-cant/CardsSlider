using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(TMPro.TMP_Dropdown))]
public class ChangeGameLanguage : MonoBehaviour
{
    private TMPro.TMP_Dropdown _dropdownList;
    private GameSettings _gameSettings;
    private Localization _localization;
 

    private void Awake(){
        _dropdownList = GetComponent<TMPro.TMP_Dropdown>(); 
        _dropdownList.value = _gameSettings.SelectedLanguage;
    }

    [Inject]
    public void Construct(GameSettings gameSettings, Localization localization){
        _gameSettings = gameSettings;
        _localization = localization;
    }

    private void OnEnable(){
        _dropdownList.onValueChanged.AddListener(OnValueDropdownChanged);
    }

    private void OnDisable(){
        _dropdownList.onValueChanged.RemoveListener(OnValueDropdownChanged);
    }

    private void OnValueDropdownChanged(int value){
        _localization.ChangeLanguage(value);
    }
}
