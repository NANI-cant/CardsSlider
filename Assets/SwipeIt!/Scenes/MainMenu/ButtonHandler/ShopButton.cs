using StartMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopButton : MonoBehaviour {
    [SerializeField] private MovableFigure[] figures;

    private SwipeHandler _swipeHandler;
    private Button buttonMenuSections;

    [Inject]
    public void Construct(SwipeHandler swipeHandler) {
        _swipeHandler = swipeHandler;
    }

    private void Awake() {
        buttonMenuSections = GetComponent<Button>();
    }

    private void OnEnable() {
        buttonMenuSections.onClick.AddListener(OpenShop);
    }

    private void OnDisable() {
        buttonMenuSections.onClick.RemoveListener(OpenShop);
    }

    private void MoveFiguresOutOfBorder() {
        foreach (MovableFigure figure in figures) {
            figure.MoveForShopScreen();
        }
    }

    private void OpenShop() {
        _swipeHandler.enabled = false;
        MoveFiguresOutOfBorder();
    }
}
