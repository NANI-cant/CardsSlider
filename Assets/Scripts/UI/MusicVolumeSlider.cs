using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Slider))]
public class MusicVolumeSlider : MonoBehaviour
{
    private Slider _slider;
    private GameSettings _gameSettings;

    [Inject]
    public void Construct(GameSettings gameSettings){
        _gameSettings = gameSettings;
    }

    private void Awake(){
        _slider = GetComponent<Slider>(); 
        _slider.value = _gameSettings.MusicVolume;
    }

    private void OnEnable() => _slider.onValueChanged.AddListener(OnSliderValueChanged);
    private void OnDisable() => _slider.onValueChanged.RemoveListener(OnSliderValueChanged);

    private void OnSliderValueChanged(float value) => _gameSettings.MusicVolume = value;
}
