using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGenerator : MonoBehaviour {
    [SerializeField] private FiguresBank figuresBank;
    [SerializeField] private int figuresCount;
    [SerializeField] private FigureData targetFigure;
    [SerializeField] private float targetFigureOnCardChance = 0.5f;
    [Header("Debug")]
    [SerializeField] private List<FigureData> debugChosenFigures;

    private void Start() {
        Generate();
    }

    private void Generate() {
        List<FigureData> chosenFigures = new List<FigureData>(figuresCount);
        debugChosenFigures = new List<FigureData>(figuresCount);
        List<FigureData> allFigures = new List<FigureData>(figuresBank.Figures);

        targetFigure = Randomizer.TakeRandomFromList<FigureData>(allFigures, targetFigure);

        if (Randomizer.RandomChance(targetFigureOnCardChance)) {
            chosenFigures[Random.Range(0, chosenFigures.Count)] = targetFigure;
        }

        for (int i = 0; i < chosenFigures.Count; i++) {
            //if (chosenFigures == null) {
            chosenFigures[i] = Randomizer.TakeRandomFromList<FigureData>(allFigures, targetFigure);
            debugChosenFigures[i] = Randomizer.TakeRandomFromList<FigureData>(allFigures, targetFigure);
            //}
        }
    }
}
