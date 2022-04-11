using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class FigureCollectionsHolder : MonoBehaviour {
    public UnityAction<FiguresBank> CollectionChanged;

    private FiguresBank _selectedCollection;
    private GameSettings _gameSettings;

    [Inject]
    public void Construct(GameSettings gameSettings) {
        _gameSettings = gameSettings;
        _selectedCollection = _gameSettings.SelectedFiguresCollection;
    }

    private void Start() {
        SelectBank(_selectedCollection);
    }

    public void SelectBank(FiguresBank bank) {
        _selectedCollection = bank;
        _gameSettings.SelectedFiguresCollection = _selectedCollection;
        CollectionChanged?.Invoke(_selectedCollection);
    }
}
