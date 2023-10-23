using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

namespace Tests {
    public class DraggingTests {
        [Test]
        public void DraggingTestsSimplePasses() {
            IInputService input = new TestInput();
            var gameObject = new GameObject();
            var cardDragger = gameObject.AddComponent<CardDragger>();
            cardDragger.Construct(null, input);
        }
    }

    internal class TestInput : IInputService {
        private Vector2 _delta;
        private Vector2 _position;
        private bool _enabled = true;

        public Vector2 Position => _position;
        public Vector2 Delta => _delta;

        public event UnityAction<Swipe> SwipeDetected;
        public event UnityAction Pressed;
        public event UnityAction Canceled;

        public void Disable() => _enabled = false;
        public void Enable() => _enabled = true;
        public void Press() {
            if (_enabled) Pressed?.Invoke();
        }
        public void Cancel() {
            if (_enabled) Canceled?.Invoke();
        }
        public void Swipe(Swipe swipe) {
            if (_enabled) SwipeDetected?.Invoke(swipe);
        }
        public void SetPosition(Vector2 position) => _position = position;
        public void SetDelta(Vector2 delta) => _delta = delta;
    }
}
