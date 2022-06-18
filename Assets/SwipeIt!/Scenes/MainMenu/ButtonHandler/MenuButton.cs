﻿using StartMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour {
    [SerializeField] private MovableFigures[] figures;

    private SwipeHandler _swipeHandler;
    private Button buttonMenuSections;

    [Inject]
    public void Construct(SwipeHandler swipeHandler) {
        _swipeHandler = swipeHandler;
    }

    private void Awake() {
        buttonMenuSections = GetComponent<Button>();
    }

    private void OnEnable() {
        buttonMenuSections.onClick.AddListener(OpenSettings);
    }

    private void OnDisable() {
        buttonMenuSections.onClick.RemoveListener(OpenSettings);
    }

    private void MoveFiguresToBorder() {
        foreach (MovableFigures figure in figures) {
            figure.MoveToBorder();
        }
    }

    private void OpenSettings() {
        _swipeHandler.enabled = false;
        MoveFiguresToBorder();
    }
}
