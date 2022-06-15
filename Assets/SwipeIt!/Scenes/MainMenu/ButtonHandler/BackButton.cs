using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackButton : MonoBehaviour
{
    [SerializeField] private MovableFigures[] figures;
    [SerializeField] private StartMenu.SwipeHandler _swipeHandler;

    private Button backButton;
    
    private void Awake(){
        backButton = GetComponent<Button>();
    }

    private void OnEnable(){
        backButton.onClick.AddListener(GoBack);
    }

    private void OnDisable(){
        backButton.onClick.RemoveListener(GoBack);
    }

    public void MoveFiguresToStart(){
        foreach(MovableFigures figure in figures){
            figure.MoveToStartPosition();
        }
    }  

    public void GoBack(){
        _swipeHandler.enabled = true;
        MoveFiguresToStart();
    }
}
