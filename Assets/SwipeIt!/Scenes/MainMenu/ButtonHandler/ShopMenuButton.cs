using UnityEngine;
using UnityEngine.UI;

public class ShopMenuButton : MonoBehaviour
{
    [SerializeField] private MovableFigures[] figures;
    [SerializeField] private StartMenu.SwipeHandler _swipeHandler;
    
    private Button buttonMenuSections;

    private void Awake(){
        buttonMenuSections = GetComponent<Button>();
    }

    private void OnEnable(){
        buttonMenuSections.onClick.AddListener(OpenShop);
    }

    private void OnDisable(){
        buttonMenuSections.onClick.RemoveListener(OpenShop);
    }

    public void MoveFiguresOutOfBorder(){
        foreach(MovableFigures figure in figures){
            figure.MoveForShopScreen();
        }
    }

    public void OpenShop(){
        _swipeHandler.enabled = false;
        MoveFiguresOutOfBorder();
    }
}
