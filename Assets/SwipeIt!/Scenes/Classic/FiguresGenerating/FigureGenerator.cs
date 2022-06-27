using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class FigureGenerator : MonoBehaviour {
    [SerializeField][Range(0, 1)] private float _targetFigureOnCardChance = 0.5f;

    public UnityAction<FigureData> OnFigureGenerated;

    private int _figuresCount;
    private int _maxFiguresCount;
    private int _answersForAddFigure;
    private int _remindAnswers;

    private FiguresCollection _figuresBank;
    private CardSpawner _spawner;
    private FigureData _targetFigure;
    private Timer _timer;

    [Inject]
    public void Construct(CardSpawner cardSpawner, Timer timer, GameplaySettings settings, GameSettings gameSettings) {
        _spawner = cardSpawner;
        _timer = timer;
        _figuresCount = settings.StartFiguresCount;
        _maxFiguresCount = settings.MaxFiguresCount;
        _answersForAddFigure = settings.AnswersForAddFigure;
        _figuresBank = gameSettings.SelectedFiguresCollection;
    }

    private void OnEnable() {
        AnswerChecker.OnAnswerCheck += HandleAnswer;
        _timer.OnTimesUp += Generate;
    }

    private void OnDisable() {
        AnswerChecker.OnAnswerCheck -= HandleAnswer;
        _timer.OnTimesUp -= Generate;
    }

    private void Start() {
        Generate();
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

        OnFigureGenerated?.Invoke(_targetFigure);
        _spawner.Spawn(new List<FigureData>(chosenFigures));
    }
}
