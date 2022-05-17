using DG.Tweening;
using UnityEngine;
using Zenject;

public class MovableFigures : MonoBehaviour {
    [Header("To border")]
    [SerializeField] private Vector2 _pointOnBorderFormal;

    [Header("Out of border")]
    [SerializeField] private Vector2 _pointOutOfBorderFormal;

    private const float TEMPLATE_SCREEN_HEIGHT = 1920f;
    private const float TEMPLATE_SCRENN_WIDTH = 1080f;
    private const float DURATION_ANIMATION = 0.5f;

    private RectTransform _rectTransform;
    private Vector2 _startPoint;
    private Camera _camera;
    private float _calculatedNewHeight;
    private float _calculatedNewWidth;


    [Inject]
    public void Construct(Camera camera) {
        _camera = camera;
    }

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        CalculateNewScreenSize();
    }

    private void Start() {
        _startPoint = _rectTransform.localPosition;
    }

    public void MoveToBorder() {
        Vector2 _endPoint;

        _endPoint.x = _calculatedNewWidth * _pointOnBorderFormal.x;
        _endPoint.y = _calculatedNewHeight * _pointOnBorderFormal.y;
        _rectTransform.DOAnchorPos(_endPoint, DURATION_ANIMATION);
    }

    public void MoveOutOfBorder() {
        Vector2 _endPoint;

        _endPoint.x = _calculatedNewWidth * _pointOutOfBorderFormal.x;
        _endPoint.y = _calculatedNewHeight * _pointOutOfBorderFormal.y;
        _rectTransform.DOAnchorPos(_endPoint, DURATION_ANIMATION);
    }

    public void MoveToStartPosition() {
        _rectTransform.DOAnchorPos(_startPoint, DURATION_ANIMATION);
    }

    private void CalculateNewScreenSize() {
        float heightFactor = _camera.pixelHeight / TEMPLATE_SCREEN_HEIGHT;
        float widthFactor = _camera.pixelWidth / TEMPLATE_SCRENN_WIDTH;
        float averageFactor = (heightFactor + widthFactor) / 2f;

        _calculatedNewHeight = _camera.pixelHeight / averageFactor;
        _calculatedNewHeight = _calculatedNewHeight / 2f;

        _calculatedNewWidth = _camera.pixelWidth / averageFactor;
        _calculatedNewWidth = _calculatedNewWidth / 2f;
    }

    private void OnDrawGizmosSelected() {
        Vector2 _pointOnBorderFormalGizmos;
        _pointOnBorderFormalGizmos.x = _pointOnBorderFormal.x * 2.8123f;
        _pointOnBorderFormalGizmos.y = _pointOnBorderFormal.y * 5f;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_startPoint, 0.1f);
        Gizmos.DrawWireSphere(_pointOnBorderFormalGizmos, 0.1f);
    }

}
