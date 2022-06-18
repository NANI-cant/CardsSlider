using UnityEngine;
using UnityEngine.UI;
using Zenject;
using StartMenu;

[RequireComponent(typeof(Button))]
public class BackButton : MonoBehaviour {
    [SerializeField] private MovableFigures[] figures;

    private SwipeHandler _swipeHandler;
    private Button backButton;

    [Inject]
    public void Construct(SwipeHandler swipeHandler){
        _swipeHandler = swipeHandler;
    }

    private void Awake() {
        backButton = GetComponent<Button>();
    }

    private void OnEnable() {
        backButton.onClick.AddListener(GoBack);
    }

    private void OnDisable() {
        backButton.onClick.RemoveListener(GoBack);
    }

    private void MoveFiguresToStart() {
        foreach (MovableFigures figure in figures) {
            figure.MoveToStartPosition();
        }
    }

    private void GoBack() {
        _swipeHandler.enabled = true;
        MoveFiguresToStart();
    }
}
