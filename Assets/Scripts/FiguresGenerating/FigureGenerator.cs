using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CardSpawner))]
public class FigureGenerator : MonoBehaviour {
    [SerializeField] private FiguresBank _figuresBank;
    [SerializeField] private int _figuresCount;
    [SerializeField] private int _maxFiguresCount;
    [SerializeField] private int _answersForAddFigure;
    [Range(0, 1)]
    [SerializeField] private float _targetFigureOnCardChance = 0.5f;
    [SerializeField] private TargetFigureView _view;
    [SerializeField] private Timer _timer;
    [Header("Debug")]
    [SerializeField] private FigureData[] _debugChosenFigures;
    [SerializeField] private FigureData _debugTargetFigure;

    private CardSpawner _spawner;
    private FigureData _targetFigure;
    private UnityAction _reGenerate;
    private int _remindAnswers;

    public UnityAction<FigureData> OnFigureGenerated;

    private void OnValidate() {
        if (_figuresCount < 1) _figuresCount = 1;
        if (_maxFiguresCount < 1) _maxFiguresCount = 1;
        if (_answersForAddFigure < 1) _answersForAddFigure = 1;
    }

    private void Awake() {
        _spawner = GetComponent<CardSpawner>();
    }

    private void Start() {
        Generate();
    }

    public void Initialize(int startFigures, int maxFiguresCount, int answersForAddFigure) {
        _maxFiguresCount = maxFiguresCount;
        _figuresCount = startFigures;
        _answersForAddFigure = answersForAddFigure;
        _remindAnswers = _answersForAddFigure;
    }

    private void OnEnable() {
        _reGenerate = () => {
            _spawner.DestroyCard();
            Generate();
        };

        AnswerChecker.OnAnswerCheck += HandleAnswer;
        _timer.OnTimesUp += _reGenerate;
    }

    private void OnDisable() {
        AnswerChecker.OnAnswerCheck -= HandleAnswer;
        _timer.OnTimesUp -= _reGenerate;
    }

    private void HandleAnswer(bool answer) {
        if (answer == true) {
            _remindAnswers--;
            if (_remindAnswers <= 0) {
                if (_figuresCount < _maxFiguresCount) {
                    _figuresCount++;
                }
                _remindAnswers = _answersForAddFigure;
            }
        }
        Generate();
    }

    [ContextMenu("Call Generate")]
    private void Generate() {
        FigureData[] chosenFigures = new FigureData[_figuresCount];
        List<FigureData> allFigures = new List<FigureData>(_figuresBank.Figures);

        _targetFigure = Randomizer.TakeRandomFromList<FigureData>(allFigures, _targetFigure);

        if (Randomizer.RandomChance(_targetFigureOnCardChance)) {
            chosenFigures[Random.Range(0, chosenFigures.Length)] = _targetFigure;
        }

        for (int i = 0; i < chosenFigures.Length; i++) {
            if (chosenFigures[i] == null) {
                chosenFigures[i] = Randomizer.TakeRandomFromList<FigureData>(allFigures, _targetFigure);
            }
        }

        _debugChosenFigures = chosenFigures;
        _view.SetImage(_targetFigure.Sprite);
        OnFigureGenerated?.Invoke(_targetFigure);
        _spawner.Spawn(new List<FigureData>(chosenFigures));
    }
}
