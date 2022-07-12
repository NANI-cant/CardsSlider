using System;
using UnityEngine;

namespace DG.Tweening {
    [Serializable]
    public class PunchOptions {
        public Vector3 Punch = Vector3.one;
        public float Duration = 0f;
        public int Vibrato = 10;
        public float Elacticity = 1;
    }
}
