using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEaseIn : MonoBehaviour {
    [SerializeField] private float _duration = 1f;

    private AudioSource _source;

    private void Awake() {
        _source = GetComponent<AudioSource>();
    }

    private void Start() {
        float targetVolume = _source.volume;
        _source.volume = 0;
        _source.DOFade(targetVolume, _duration).SetEase(Ease.InQuad);
    }
}
