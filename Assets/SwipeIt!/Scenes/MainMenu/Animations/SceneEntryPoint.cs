using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SceneEntryPoint : MonoBehaviour
{
    [SerializeField] private MovableFigures[] _figures;
    [SerializeField] private MovableCardFigure _card;
    [SerializeField] private CanvasGroup[] _canvasesFade;

    private const float FADE_DURATION = 0.4f;

    void Start()
    {   
        foreach(CanvasGroup canvas in _canvasesFade){
            canvas.DOFade(0, 0f);
            canvas.DOFade(1, FADE_DURATION);
        }
        foreach(MovableFigures figure in _figures){
            figure.StartMove();
        }
        _card.StartAnimation();
    }
}
