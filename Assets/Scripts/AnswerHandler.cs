using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Mode {
    Classic,
    Arcade,
    Hard,
    Relax,
}

public class AnswerHandler : MonoBehaviour {
    [SerializeField] private Mode gameMode = Mode.Classic;

    [Header("Classic")]
    [SerializeField] private float settingTime;
    [SerializeField] private float addingScore;
    [SerializeField] private uint takingLifes;

    [Header("References")]
    [SerializeField] private Timer timer;
    [SerializeField] private AnswerChecker yesCheck;
    [SerializeField] private AnswerChecker noCheck;

    private void OnEnable() {
        yesCheck.OnAnswerCheck += ReactToAnswer;
        noCheck.OnAnswerCheck += ReactToAnswer;
    }

    private void OnDisable() {
        yesCheck.OnAnswerCheck -= ReactToAnswer;
        noCheck.OnAnswerCheck -= ReactToAnswer;
    }

    private void ReactToAnswer(bool answer) {
        timer.Run();
        switch (gameMode) {
            case Mode.Classic: {
                    timer.Set(settingTime);
                    break;
                }
            default: {
                    break;
                }
        }
    }
}
