using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureData", menuName = "ScriptableObjects/FigureData")]
public class FigureData : ScriptableObject {
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _id;

    public Sprite Sprite => _sprite;
    public string Id => _id;
}
