using System;

namespace DG.Tweening {
    [Serializable]
    public class ShakeOptions {
        public float Duration;
        public float Strength = 90;
        public int Vibrato = 10;
        public float Randomness = 90;
        public bool FadeOut = true;
    }
}
