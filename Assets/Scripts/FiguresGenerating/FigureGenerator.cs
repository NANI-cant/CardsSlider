using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGenerator : MonoBehaviour {
    [SerializeField] private FiguresBank figuresBank;
    [SerializeField] private int figuresCount;
    [SerializeField] private float targetFigureOnCardChance = 0.5f;
    [SerializeField] private CardSpawner spawner;
    [SerializeField] private AnswerChecker yesCheck;
    [SerializeField] private AnswerChecker noCheck;
    [Header("Debug")]
    [SerializeField] private FigureData[] debugChosenFigures;
    [SerializeField] private FigureData debugTargetFigure;

    private FigureData targetFigure;

    private void Start() {
        Generate();
    }

    private void OnEnable() {
        yesCheck.OnAnswerCheck += Generate;
        noCheck.OnAnswerCheck += Generate;
    }

    private void OnDisable() {
        yesCheck.OnAnswerCheck -= Generate;
        noCheck.OnAnswerCheck -= Generate;
    }

    [ContextMenu("Call Generate")]
    private void Generate() {
        FigureData[] chosenFigures = new FigureData[figuresCount];
        List<FigureData> allFigures = new List<FigureData>(figuresBank.Figures);

        targetFigure = Randomizer.TakeRandomFromList<FigureData>(allFigures, targetFigure);

        if (Randomizer.RandomChance(targetFigureOnCardChance)) {
            chosenFigures[Random.Range(0, chosenFigures.Length)] = targetFigure;
        }

        for (int i = 0; i < chosenFigures.Length; i++) {
            if (chosenFigures[i] == null) {
                chosenFigures[i] = Randomizer.TakeRandomFromList<FigureData>(allFigures, targetFigure);
            }
        }

        debugChosenFigures = chosenFigures;

        spawner.Spawn(new List<FigureData>(chosenFigures));
    }
}
