using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Slider))]
public class MusicVolumeSlider : MonoBehaviour
{
    private Slider _slider;
    private GameSettings _gameSettings;

    private void Awake(){
        _slider = GetComponent<Slider>(); 
        _slider.value = _gameSettings.MusicVolume;
    }

    [Inject]
    public void Construct(GameSettings gameSettings){
        _gameSettings = gameSettings;
    }

    private void OnEnable(){
        _slider.onValueChanged.AddListener(OnValueSliderChanged);
    }

    private void OnDisable(){
        _slider.onValueChanged.RemoveListener(OnValueSliderChanged);
    }

    private void OnValueSliderChanged(float value){
        _gameSettings.MusicVolume = value;
    }
}
