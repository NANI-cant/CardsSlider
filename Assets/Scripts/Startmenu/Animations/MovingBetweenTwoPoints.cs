using DG.Tweening;
using UnityEngine;
using Zenject;

public class MovingBetweenTwoPoints : MonoBehaviour {

    [SerializeField] private Vector2 _endPointFormal;

    private Vector2 _startPoint;
    private float _durationAnimation = 0.5f;
    private Camera _camera;
    private RectTransform _rectTransform;

    [Inject]
    public void Construct(Camera camera){
        _camera = camera;
        
    }

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start() {
        _startPoint = transform.position;
        MoveToOtherPoint();
    }

    private void MoveToOtherPoint() {
        Vector2 _endPoint;
        _endPoint.x = _camera.pixelWidth/2 * _endPointFormal.x;
        _endPoint.y = _camera.pixelHeight/2 * _endPointFormal.y;
        _rectTransform.DOAnchorPos(_endPoint, _durationAnimation);
        // _rectTransform.DOMove(_endPoint, _durationAnimation);
    }

    // private void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.cyan;
    //     Gizmos.DrawWireSphere(_startPoint, 0.1f);
    //     Gizmos.DrawWireSphere(_endPoint, 0.1f);
    // }
}
