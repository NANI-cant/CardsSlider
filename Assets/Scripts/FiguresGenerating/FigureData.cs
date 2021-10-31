using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureData", menuName = "ScriptableObjects/FigureData")]
public class FigureData : ScriptableObject {
    [SerializeField] private Sprite sprite;
    [SerializeField] private string id;
}
