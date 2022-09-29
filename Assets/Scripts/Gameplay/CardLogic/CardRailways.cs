using UnityEngine;

public class CardRailways : MonoBehaviour {
    [SerializeField] private Vector2 _leftPointOffset;
    [SerializeField] private Vector2 _rightPointOffset;

    private Vector2 MiddlePoint => transform.position;
    private Vector2 RightPoint => transform.TransformPoint(_rightPointOffset);
    private Vector2 LeftPoint => transform.TransformPoint(_leftPointOffset);

    private Vector2 RightDirection => (RightPoint - MiddlePoint).normalized;
    private Vector2 LeftDirection => (LeftPoint - MiddlePoint).normalized;

    private float RightDistance => Mathf.Sqrt(((RightPoint - MiddlePoint).sqrMagnitude));
    private float LeftDistance => Mathf.Sqrt(((LeftPoint - MiddlePoint).sqrMagnitude));

    public Vector2 TranslateByDistance(float distance) {
        if (distance == 0) return MiddlePoint;

        Vector2 resultPosition = Vector2.zero;

        if (distance > 0) {
            resultPosition = GetPositionOnRightLine(distance);
        }
        else {
            resultPosition = GetPositionOnLeftLine(distance);
        }

        return resultPosition;
    }

    private Vector2 GetPositionOnRightLine(float distance) {
        Vector2 rightPosition = Vector2.zero;
        if (distance >= RightDistance) {
            rightPosition = RightPoint;
        }
        else {
            rightPosition = MiddlePoint + RightDirection * distance;
        }
        return rightPosition;
    }

    private Vector2 GetPositionOnLeftLine(float distance) {
        Vector2 leftPosition = Vector2.zero;
        if (-distance >= LeftDistance) {
            leftPosition = LeftPoint;
        }
        else {
            leftPosition = MiddlePoint + LeftDirection * -distance;
        }
        return leftPosition;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(MiddlePoint, RightPoint);
        Gizmos.DrawLine(MiddlePoint, LeftPoint);

        Gizmos.DrawWireSphere(MiddlePoint, 0.1f);
        Gizmos.DrawWireSphere(LeftPoint, 0.1f);
        Gizmos.DrawWireSphere(RightPoint, 0.1f);
    }
}
