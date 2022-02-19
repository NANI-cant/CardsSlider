using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreConverter : MonoBehaviour {
    [Tooltip("Score умножается на коэффициент, результат - размер полученной валюты")]
    [SerializeField] private float _koefficient;
    [SerializeField] private float _startDelay;
    [SerializeField] private float _timeForConvert;
    [SerializeField] private TextMeshProUGUI _scoreUI;
    [SerializeField] private TextMeshProUGUI _bankUI;
    [SerializeField] private ScoreCounter _scoreCounter;

    private int _score;
    private int _bank;
    private float _currentScore;
    private float _currentBank;
    private Coroutine _convertingRoutine;

    private void OnValidate() {
        if (_timeForConvert <= 0) _timeForConvert = 0.001f;
        if (_koefficient < 0) _koefficient = 0;
        if (_startDelay < 0) _startDelay = 0;
    }

    public void StartConverting() {
        _score = _scoreCounter.Score;
        _bank = (int)(_score * _koefficient);
        PlayerPrefs.SetInt(SaveKey.Bank, PlayerPrefs.GetInt(SaveKey.Bank) + _bank);
        _currentBank = 0;
        _currentScore = _score;
        _scoreUI.text = _score.ToString();
        _convertingRoutine = StartCoroutine(nameof(Convert));
    }

    private IEnumerator Convert() {
        yield return new WaitForSeconds(_startDelay);
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
