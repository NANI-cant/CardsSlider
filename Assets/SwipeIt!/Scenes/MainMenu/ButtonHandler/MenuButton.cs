using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour
{
    [SerializeField] private MovableFigures[] figures;
    [SerializeField] private StartMenu.SwipeHandler _swipeHandler;

    private Button buttonMenuSections;

    private void Awake(){
        buttonMenuSections = GetComponent<Button>();
    }

    private void OnEnable(){
        buttonMenuSections.onClick.AddListener(OpenSettings);
    }

    private void OnDisable(){
        buttonMenuSections.onClick.RemoveListener(OpenSettings);
    }

    public void MoveFiguresToBorder(){
        foreach(MovableFigures figure in figures){
            figure.MoveToBorder();
        }
    }

    public void OpenSettings(){
        _swipeHandler.enabled = false;
        MoveFiguresToBorder();
    }
}
