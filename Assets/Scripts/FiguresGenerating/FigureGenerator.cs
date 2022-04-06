using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(CardSpawner))]
public class FigureGenerator : MonoBehaviour {
    [SerializeField] private FiguresBank _figuresBank;
    [Min(1)]
    [SerializeField] private int _figuresCount;
    [Min(1)]
    [SerializeField] private int _maxFiguresCount;
    [Min(1)]
    [SerializeField] private int _answersForAddFigure;
    [Range(0, 1)]
    [SerializeField] private float _targetFigureOnCardChance = 0.5f;

    public UnityAction<FigureData> OnFigureGenerated;

    private CardSpawner _spawner;
    private FigureData _targetFigure;
    private UnityAction _reGenerate;
    private int _remindAnswers;

    private Timer _timer;

    private void OnValidate() {
        if (_figuresCount > _maxFiguresCount) _figuresCount = _maxFiguresCount;
    }

    [Inject]
    public void Construct(Timer timer, GameplaySettings settings) {
        _timer = timer;
        _figuresCount = settings.StartFiguresCount;
        _maxFiguresCount = settings.MaxFiguresCount;
        _answersForAddFigure = settings.AnswersForAddFigure;
    }

    private void Awake() {
        _spawner = GetComponent<CardSpawner>();
    }

    private void Start() {
        Generate();
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

        OnFigureGenerated?.Invoke(_targetFigure);
        _spawner.Spawn(new List<FigureData>(chosenFigures));
    }
}
