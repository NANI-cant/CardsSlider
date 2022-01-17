using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] AnswerHandler _answerHandler;

    private void OnEnable() {
        _answerHandler.OnLifesEnd += EndGame;
    }

    private void OnDisable() {
        _answerHandler.OnLifesEnd -= EndGame;
    }

    private void EndGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
