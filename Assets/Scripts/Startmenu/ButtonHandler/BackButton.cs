using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackButton : MonoBehaviour
{
    [SerializeField] private MovableFigures[] figures;
    private Button backButton;
    
    private void Awake(){
        backButton = GetComponent<Button>();
    }

    private void OnEnable(){
        backButton.onClick.AddListener(MoveFiguresToStart);
    }

    private void OnDisable(){
        backButton.onClick.RemoveListener(MoveFiguresToStart);
    }

    public void MoveFiguresToStart(){
        foreach(MovableFigures figure in figures){
            figure.MoveToStartPosition();
        }
    }  
}
