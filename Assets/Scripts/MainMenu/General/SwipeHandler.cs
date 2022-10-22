using UnityEngine;
using Zenject;

namespace StartMenu {
    public class SwipeHandler : MonoBehaviour {
        [SerializeField] private float _delayForAnimation = 1f;
        [SerializeField] private float _triggerMagnitudeValue;
        [SerializeField] private MenuExitView _menuExitView;

        [Header("Debug")]
        [SerializeField] private bool _shouldLog = false;

        private IInputService _input;
        private GameModePanel _gameModePanel;

        [Inject]
        public void Construct(IInputService input, GameModePanel gameModePanel) {
            _input = input;
            _gameModePanel = gameModePanel;
        }

        private void OnEnable() => _input.SwipeDetected += OnSwipeDetected;
        private void OnDisable() => _input.SwipeDetected -= OnSwipeDetected;

        private void OnSwipeDetected(Swipe swipe) {
            this.Do(() => Debug.Log($"Swipe: {swipe.Direction} {swipe.Magnitude}"), when: _shouldLog);
            if (swipe.Magnitude >= _triggerMagnitudeValue) {
                _menuExitView.Animate();
                Invoke(nameof(StartGame), _delayForAnimation);
            }
        }

        private void StartGame() => _gameModePanel.Play();
    }
}
