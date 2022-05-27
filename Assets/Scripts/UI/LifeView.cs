using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LifeView : MonoBehaviour {
    [SerializeField] private RectTransform _lifeTemplate;
    [SerializeField] private float _padding;

    private LifeCounter _lifeModel;
    private List<RectTransform> _lifes = new List<RectTransform>();

    private float XOffset => _lifeTemplate.rect.width / 2;

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
        DrawLifes(new Vector2(XOffset, 0f), lifes);
    }

    private void DrawLifes(Vector2 pointer, int count) {
        for (int i = 0; i < count; i++) {
            var life = Instantiate(_lifeTemplate, transform.position + new Vector3(1000,1000,0), Quaternion.identity, transform);
            _lifes.Add(life);
            life.anchoredPosition = pointer;
            pointer.x += _padding + _lifeTemplate.rect.width;
        }
    }

    private void ClearLifes() {
        foreach (var life in _lifes) {
            Destroy(life.gameObject);
        }
        _lifes.Clear();
    }
}
