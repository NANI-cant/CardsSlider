using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreConverter : MonoBehaviour {
    [Tooltip("Score умножается на коэффициент, результат - размер полученной валюты")]
    [Min(0)][SerializeField] private float _koefficient;
    [Min(0)][SerializeField] private float _startDelay;
    [Min(0.0001f)][SerializeField] private float _timeForConvert;
    [SerializeField] private TextMeshProUGUI _scoreUI;
    [SerializeField] private TextMeshProUGUI _bankUI;

    private ScoreCounter _scoreCounter;

    private int _score;
    private int _bank;
    private float _currentScore;
    private float _currentBank;
    private Coroutine _convertingRoutine;

    [Inject]
    public void Construct(ScoreCounter scoreCounter) {
        _scoreCounter = scoreCounter;
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
