using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LifeView : MonoBehaviour {
    [SerializeField] private RectTransform _lifeTemplate;

    private LifeCounter _lifeModel;
    private List<RectTransform> _lifes = new List<RectTransform>();

    [Inject]
    public void Construct(LifeCounter lifeCounter) {
        _lifeModel = lifeCounter;
    }

    private void OnEnable() {
        _lifeModel.OnLifesChange += ChangeUI;
    }

    private void OnDisable() {
        _lifeModel.OnLifesChange -= ChangeUI;
    }

    private void Start() {
        ChangeUI(_lifeModel.Lifes);
    }

    private void ChangeUI(int lifes) {
        ClearLifes();
        DrawLifes(lifes);
    }

    private void DrawLifes(int count) {
        for (int i = 0; i < count; i++) {
            var life = Instantiate(_lifeTemplate, transform.position, Quaternion.identity, transform);
            _lifes.Add(life);
        }
    }

    private void ClearLifes() {
        foreach (var life in _lifes) {
            Destroy(life.gameObject);
        }
        _lifes.Clear();
    }
}
