using UnityEngine;
using UnityEngine.UI;

public class ShopMenuButton : MonoBehaviour
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
            figure.MoveOutOfBorder();
        }
    }
}
