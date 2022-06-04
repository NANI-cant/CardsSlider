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
        buttonMenuSections.onClick.AddListener(MoveFiguresOutOfBorder);
    }

    private void OnDisable(){
        buttonMenuSections.onClick.RemoveListener(MoveFiguresOutOfBorder);
    }

    public void MoveFiguresOutOfBorder(){
        foreach(MovableFigures figure in figures){
            figure.MoveOutOfBorder();
        }
    }
}
