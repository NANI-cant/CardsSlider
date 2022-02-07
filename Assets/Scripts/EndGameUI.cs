using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUI : MonoBehaviour {
    [SerializeField] private RectTransform _endGamePanel;

    private void Awake() {
        _endGamePanel.gameObject.SetActive(false);
    }

    private void OnEnable() {
        ServiceLocator.GetService<LifeCounter>().OnLifesOver += OpenPanel;
    }

    private void OnDisable() {
        ServiceLocator.GetService<LifeCounter>().OnLifesOver -= OpenPanel;
    }

    private void OpenPanel() {
        _endGamePanel.gameObject.SetActive(true);
    }
}
