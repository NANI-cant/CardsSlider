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

        _game.GamePaused += SetLowpass;
        _game.GameStarted += SetDefault;
        _game.GameInterrupted += SetDefault;
        _audioMixer.GetFloat(GameplayLowpassKey, out _defaultLowpass);
    }

    private void SetDefault() {
        _audioMixer.SetFloat(GameplayLowpassKey, _defaultLowpass);
    }

    private void SetLowpass() {
        _audioMixer.SetFloat(GameplayLowpassKey, _pausedLowpass);
    }
}
