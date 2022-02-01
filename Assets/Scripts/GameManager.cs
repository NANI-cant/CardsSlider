using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private uint _startLifes;

    private LifeCounter _life;

    private void Awake() {
        ServiceLocator.RegisterService<GameManager>(this);
        _life = ServiceLocator.GetService<LifeCounter>();
        _life.Initialize((int)_startLifes);
    }

    private void OnEnable() {
        _life.OnLifesOver += EndGame;
    }

    private void OnDisable() {
        _life.OnLifesOver -= EndGame;
    }

    private void EndGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
