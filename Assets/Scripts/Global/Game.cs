﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour {
    [SerializeField] private LifeCounter _life;

    public UnityAction OnSceneStart;
    public UnityAction OnGameStart;
    public UnityAction OnGameOver;

    private void OnEnable() {
        _life.OnLifesOver += OnPlayerLifesOver;
    }

    private void OnDisable(){
        _life.OnLifesOver -= OnPlayerLifesOver;
    }

    private void Start() {
        OnSceneStart?.Invoke();
    }

    private void OnPlayerLifesOver() {
        OnGameOver?.Invoke();
    }
}