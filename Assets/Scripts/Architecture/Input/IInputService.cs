using UnityEngine;
using UnityEngine.Events;

public interface IInputService : IEnable, IDisable {
    event UnityAction<Swipe> SwipeDetected;
    event UnityAction Pressed;
    event UnityAction Canceled;

    Vector2 Position { get; }
    Vector2 Delta { get; }
}
