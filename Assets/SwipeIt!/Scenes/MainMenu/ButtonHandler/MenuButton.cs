using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour
{
    [SerializeField] private MovableFigures[] figures;
    private Button buttonMenuSections;

    private void Awake(){
        buttonMenuSections = GetComponent<Button>();
    }

    private void OnEnable(){
        buttonMenuSections.onClick.AddListener(MoveFiguresToBorder);
    }

    private void OnDisable(){
        buttonMenuSections.onClick.RemoveListener(MoveFiguresToBorder);
    }

    public void MoveFiguresToBorder(){
        foreach(MovableFigures figure in figures){
            figure.MoveToBorder();
        }
    }
}
