using UnityEngine;
using Zenject;

namespace StartMenu {
    public class SwipeHandler : MonoBehaviour {
        private IInputService _input;
        [Header("Debug")]
        [SerializeField] private bool _shouldLog = false;

        [Inject]
        public void Construct(IInputService input) {
            _input = input;
        }

        private void OnEnable() {
            _input.SwipeDetected += OnSwipeDetected;
        }

        private void OnDisable() {
            _input.SwipeDetected -= OnSwipeDetected;
        }

        private void OnSwipeDetected(Swipe swipe) {
            this.Do(() => Debug.Log($"Swipe: {swipe.Direction} {swipe.Magnitude}"), when: _shouldLog);
        }
    }
}
