using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FiguresBank", menuName = "ScriptableObjects/FiguresBank")]
public class FiguresBank : ScriptableObject {
    [SerializeField] private int _id;
    [SerializeField] private List<FigureData> _figures;

    public IEnumerable<FigureData> Figures => _figures;
    public int Id => _id;
}
