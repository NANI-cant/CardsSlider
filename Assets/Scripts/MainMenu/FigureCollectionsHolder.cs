using System;
using UnityEngine;
using Zenject;

public class FigureCollectionsHolder : MonoBehaviour {
    public event Action<FiguresCollection> CollectionChanged;

    private FiguresCollection _selectedCollection;
    private GameSettings _gameSettings;

    public FiguresCollection SelectedCollection => _selectedCollection;

    [Inject]
    public void Construct(GameSettings gameSettings) {
        _gameSettings = gameSettings;
        _selectedCollection = _gameSettings.SelectedFiguresCollection;
    }

    private void Start() {
        SelectCollection(_selectedCollection);
    }

    public void SelectCollection(FiguresCollection collection) {
        _selectedCollection = collection;
        _gameSettings.SelectedFiguresCollection = _selectedCollection;
        CollectionChanged?.Invoke(_selectedCollection);
    }
}
