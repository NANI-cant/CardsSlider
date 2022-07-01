using System;

[Serializable]
public class ShakeOptions {
    public float Duration;
    public float Strength = 90;
    public int Vibrato = 10;
    public float Randomness = 90;
    public bool FadeOut = true;

    public ShakeOptions(float duration, float strength = 90, int vibrato = 10, float randomness = 90, bool fadeOut = true) {
        Duration = duration;
        Strength = strength;
        Vibrato = vibrato;
        Randomness = randomness;
        FadeOut = fadeOut;
    }
}
