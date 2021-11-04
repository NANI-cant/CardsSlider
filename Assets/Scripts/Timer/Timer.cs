using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {
    [SerializeField] private float startTime;
    [SerializeField] private TimerVizualizer vizualizer;
    [Header("Debug")]
    [SerializeField] private float debugRemaindedTime;

    private float remaindedTime;
    private bool isRun = false;

    public UnityAction OnTimesUp;

    public float RemaindedTime => remaindedTime;

    private void Start() {
        remaindedTime = startTime;
        debugRemaindedTime = remaindedTime;
        vizualizer.Visualize(remaindedTime);
    }

    private void Update() {
        if (isRun) {
            Running();
        }
    }

    public void Add(float time) {
        remaindedTime += time;
        debugRemaindedTime = remaindedTime;
    }

    public void Set(float time) {
        remaindedTime = time;
        debugRemaindedTime = remaindedTime;
    }

    [ContextMenu("Run")]
    public void Run() {
        if (!isRun) {
            isRun = true;
        }
    }

    [ContextMenu("Stop")]
    private void Stop() {
        if (isRun) {
            isRun = false;
            OnTimesUp?.Invoke();
        }
    }

    private void Running() {
        remaindedTime -= Time.deltaTime;
        vizualizer.Visualize(remaindedTime);
        debugRemaindedTime = remaindedTime;
        if (remaindedTime <= Constants.epsilon) {
            Stop();
        }
    }
}
