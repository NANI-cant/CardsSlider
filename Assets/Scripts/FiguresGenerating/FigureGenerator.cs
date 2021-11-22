using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGenerator : MonoBehaviour {
    [SerializeField] private FiguresBank _figuresBank;
    [SerializeField] private int _figuresCount;
    [SerializeField] private float _targetFigureOnCardChance = 0.5f;
    [SerializeField] private TargetVisualizer _visualizer;
    [SerializeField] private CardSpawner _spawner;
    [SerializeField] private AnswerChecker _yesCheck;
    [SerializeField] private AnswerChecker _noCheck;
    [Header("Debug")]
    [SerializeField] private FigureData[] _debugChosenFigures;
    [SerializeField] private FigureData _debugTargetFigure;

    private FigureData _targetFigure;

    private void Start() {
        Generate();
    }

    private void OnEnable() {
        _yesCheck.OnAnswerCheck += Generate;
        _noCheck.OnAnswerCheck += Generate;
    }

    private void OnDisable() {
        _yesCheck.OnAnswerCheck -= Generate;
        _noCheck.OnAnswerCheck -= Generate;
    }

    [ContextMenu("Call Generate")]
    private void Generate(bool arg = false) {
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
