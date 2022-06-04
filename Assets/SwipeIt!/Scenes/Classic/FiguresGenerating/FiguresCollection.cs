using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FiguresCollection", menuName = "ScriptableObjects/FiguresCollection")]
public class FiguresCollection : ScriptableObject {
    [SerializeField] private List<FigureData> _figures;

    public IEnumerable<FigureData> Figures => _figures;
}
