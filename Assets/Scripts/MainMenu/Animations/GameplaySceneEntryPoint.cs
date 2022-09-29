using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameplaySceneEntryPoint : MonoBehaviour
{
    [SerializeField] private MovableFigure[] _figures;
    [SerializeField] private MovableCardFigure _card;
    [SerializeField] private CanvasGroup[] _canvasesFade;

    private const float FADE_DURATION = 0.4f;

    void Start()
    {   
        foreach(CanvasGroup canvas in _canvasesFade){
            canvas.DOFade(0, 0f);
            canvas.DOFade(1, FADE_DURATION);
        }
        foreach(MovableFigure figure in _figures){
            figure.StartMove();
        }
        _card.StartAnimation();
    }
}
