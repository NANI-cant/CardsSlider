using UnityEngine;

public class BackButtonHandler : MonoBehaviour
{
    [SerializeField] private MovingFigures[] figures;
    
    public void MoveFiguresToStart(){
        foreach(MovingFigures figure in figures){
            figure.ToStartPosition();
        }
    }  
}
