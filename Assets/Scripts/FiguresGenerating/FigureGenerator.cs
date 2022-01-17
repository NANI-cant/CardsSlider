using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FigureGenerator : MonoBehaviour {
    [SerializeField] private FiguresBank _figuresBank;
    [SerializeField] private int _figuresCount;
    [SerializeField] private float _targetFigureOnCardChance = 0.5f;
    [SerializeField] private TargetVisualizer _visualizer;
    [SerializeField] private CardSpawner _spawner;
    [SerializeField] private AnswerChecker _yesCheck;
    [SerializeField] private AnswerChecker _noCheck;
    [SerializeField] private Timer _timer;
    [Header("Debug")]
    [SerializeField] private FigureData[] _debugChosenFigures;
    [SerializeField] private FigureData _debugTargetFigure;

    private FigureData _targetFigure;
    private UnityAction<bool> _generateBool;
    private UnityAction _reGenerate;

    private void Start() {
        Generate();
    }

    private void OnEnable() {
        _generateBool = (arg) => Generate();
        _reGenerate = () => {
            _spawner.DestroyCard();
            Generate();
        };

        _yesCheck.OnAnswerCheck += _generateBool;
        _noCheck.OnAnswerCheck += _generateBool;
        _timer.OnTimesUp += _reGenerate;
    }

    private void OnDisable() {
        _yesCheck.OnAnswerCheck -= _generateBool;
        _noCheck.OnAnswerCheck -= _generateBool;
        _timer.OnTimesUp -= _reGenerate;
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

        _visualizer.SetImage(_targetFigure.Sprite);
        _yesCheck.TargetId = _targetFigure.Id;
        _noCheck.TargetId = _targetFigure.Id;
        _spawner.Spawn(new List<FigureData>(chosenFigures));
    }
}
