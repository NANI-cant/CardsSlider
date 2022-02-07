using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreConverter : MonoBehaviour {
    [Tooltip("Score умножается на коэффициент, результат - размер полученной валюты")]
    [SerializeField] private float _koefficient;
    [SerializeField] private float _timeForConvert;
    [SerializeField] private TextMeshProUGUI _scoreUI;
    [SerializeField] private TextMeshProUGUI _bankUI;

    private int _score;
    private int _bank;
    private float _currentScore;
    private float _currentBank;
    private Coroutine _convertingRoutine;

    private void Start() {
        _score = ServiceLocator.GetService<ScoreCounter>().Score;
        //_score = FindObjectOfType<ScoreCounter>().Score;
        _bank = (int)(_score * _koefficient);
        _currentBank = 0;
        _currentScore = _score;
        _scoreUI.text = _score.ToString();
        StartConverting();
    }

    private void StartConverting(){
        _convertingRoutine = StartCoroutine(nameof(Convert));
    }

    private IEnumerator Convert() {
        while (_currentScore != 0 && _currentBank != _bank) {
            _currentBank += _bank / _timeForConvert * Time.deltaTime;
            if (_currentBank >= _bank) {
                _currentBank = _bank;
            }

            _currentScore -= _score / _timeForConvert * Time.deltaTime;
            if (_currentScore <= 0) {
                _currentScore = 0;
            }

            _scoreUI.text = ((int)_currentScore).ToString();
            _bankUI.text = ((int)_currentBank).ToString();
            yield return new WaitForEndOfFrame();
        }
    }
}
