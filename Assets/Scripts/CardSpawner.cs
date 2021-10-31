using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {
    [SerializeField] private Card cardTemplate;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private AnswerChecker yesCheck;
    [SerializeField] private AnswerChecker noCheck;

    [Header("Debug")]
    [SerializeField] private Color debugColor;
    [SerializeField] private Vector2 debugCardSize;

    private void OnEnable() {
        yesCheck.OnAnswerCheck += Spawn;
        noCheck.OnAnswerCheck += Spawn;
    }

    private void OnDisable() {
        yesCheck.OnAnswerCheck -= Spawn;
        noCheck.OnAnswerCheck -= Spawn;
    }

    private void Start() {
        Spawn();
    }

    private void Spawn() {
        Card card = Instantiate(cardTemplate, spawnPosition, Quaternion.identity);
        Debug.Log("Spawn new Card");
    }

    private void OnDrawGizmos() {
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(spawnPosition, debugCardSize);
    }
}
