using System;
using UnityEngine.Audio;

public class AudioEffectHandler {
    private const string GameplayLowpassKey = "GameplayLowpass";

    private Game _game;
    private AudioMixer _audioMixer;
    private float _defaultLowpass;
    private float _pausedLowpass = 600f;

    public AudioEffectHandler(Game game, AudioMixer audioMixer) {
        _game = game;
        _audioMixer = audioMixer;

        _game.GamePaused += OnGamePaused;
        _game.GameStarted += OnGameStarted;
        _audioMixer.GetFloat(GameplayLowpassKey, out _defaultLowpass);
    }

    private void OnGameStarted() {
        _audioMixer.SetFloat(GameplayLowpassKey, _defaultLowpass);
    }

    private void OnGamePaused() {
        _audioMixer.SetFloat(GameplayLowpassKey, _pausedLowpass);
    }
}
