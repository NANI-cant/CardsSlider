using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FiguresBank", menuName = "ScriptableObjects/FiguresBank")]
public class FiguresBank : ScriptableObject {
    [SerializeField] private List<FigureData> figures;

    public IEnumerable<FigureData> Figures => figures;
}
