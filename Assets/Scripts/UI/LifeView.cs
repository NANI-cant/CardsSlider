using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class LifeView : MonoBehaviour {
    [SerializeField] private RectTransform _lifeTemplate;
    [SerializeField] private ParticleSystem _lifeKilling;

    [Header("Tweening")]
    [SerializeField] private ShakeOptions _shakeRotation;

    private LifeCounter _lifeModel;
    private Stack<RectTransform> _lifes = new Stack<RectTransform>();

    private int CurrentLifes => _lifes.Count;

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
        DrawLifes(_lifeModel.Lifes);
    }

    private void ChangeUI(int lifes) {
        int lifesDelta = CurrentLifes - lifes;
        if (lifesDelta > 0) {
            ClearLifes(lifesDelta);
            TweenLifes();
        }
        else {
            DrawLifes(-lifesDelta);
        }
    }

    private void DrawLifes(int count) {
        for (int i = 0; i < count; i++) {
            var life = Instantiate(_lifeTemplate, transform);
            _lifes.Push(life);
        }
    }

    private void ClearLifes(int count) {
        for (int i = 0; i < count; i++) {
            var clearedLife = _lifes.Pop();
            Instantiate(_lifeKilling, clearedLife.transform.position, Quaternion.identity, transform);
            Destroy(clearedLife.gameObject);
        }
    }

    private void TweenLifes() {
        foreach (var life in _lifes) {
            life
                .DOShakeRotation(_shakeRotation.Duration, _shakeRotation.Strength, _shakeRotation.Vibrato)
                .onUpdate += () => {
                    Vector3 eulerRotation = life.rotation.eulerAngles;
                    eulerRotation.x = 0f;
                    eulerRotation.y = 0f;
                    life.rotation = Quaternion.Euler(eulerRotation);
                };
        }
    }
}
