using UnityEngine;

public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField] private MovingFigures[] figures;

    public void MoveFiguresToBorder(){
        foreach(MovingFigures figure in figures){
            figure.ToBorder();
        }
    }
}
