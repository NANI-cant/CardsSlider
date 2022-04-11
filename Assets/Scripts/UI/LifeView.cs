using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LifeView : MonoBehaviour {
    private TextMeshProUGUI _uGUI;

    private LifeCounter _lifeModel;

    [Inject]
    public void Construct(LifeCounter lifeCounter) {
        _lifeModel = lifeCounter;
    }

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
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
        _uGUI.text = lifes.ToString();
    }
}
