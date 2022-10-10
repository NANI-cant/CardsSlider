using DG.Tweening;
using UnityEngine;
using Zenject;

public class MovableFigure : MonoBehaviour {
    [Header("To border")]
    [SerializeField] private Vector2 _pointOnBorderFormal;

    [Header("Out of border")]
    [SerializeField] private Vector2 _pointOutOfBorderFormal;

    [Header("For shop")]
    [SerializeField] private Vector2 _pointForShop;

    private const float TemplateScreenHeight = 1920f;
    private const float TemplateScreenWidth = 1080f;
    private const float DurationAnimation = 0.5f;

    private RectTransform _rectTransform;
    private Vector2 _startPoint;
    private Camera _camera;
    private float _calculatedNewHeight;
    private float _calculatedNewWidth;
    private Tweener _tweener;


    [Inject]
    public void Construct(Camera camera) {
        _camera = camera;
    }

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        CalculateNewScreenSize();
        _startPoint = _rectTransform.localPosition;
    }

    private void OnDestroy() => _tweener?.Kill();

    public void MoveToBorder() {
        Vector2 _endPoint;

        _endPoint.x = _calculatedNewWidth * _pointOnBorderFormal.x;
        _endPoint.y = _calculatedNewHeight * _pointOnBorderFormal.y;

        _tweener?.Complete();
        _tweener = _rectTransform.DOAnchorPos(_endPoint, DurationAnimation).SetEase(Ease.OutCubic);
    }

    public void StartMove() {
        Vector2 _startPointLocal;

        _startPointLocal.x = _calculatedNewWidth * _pointOutOfBorderFormal.x;
        _startPointLocal.y = _calculatedNewHeight * _pointOutOfBorderFormal.y;
        _rectTransform.localPosition = _startPointLocal;
        MoveToStartPosition();
    }

    public void MoveOutOfBorder() {
        Vector2 _endPoint;

        _endPoint.x = _calculatedNewWidth * _pointOutOfBorderFormal.x;
        _endPoint.y = _calculatedNewHeight * _pointOutOfBorderFormal.y;

        _tweener?.Complete();
        _tweener = _rectTransform.DOAnchorPos(_endPoint, DurationAnimation).SetEase(Ease.OutCubic);
    }

    public void MoveForShopScreen() {
        Vector2 _endPoint;

        _endPoint.x = _calculatedNewWidth * _pointForShop.x;
        _endPoint.y = _calculatedNewHeight * _pointForShop.y;

        _tweener?.Complete();
        _tweener = _rectTransform.DOAnchorPos(_endPoint, DurationAnimation).SetEase(Ease.OutCubic);
    }

    public void MoveToStartPosition() {
        _tweener?.Complete();
        _tweener = _rectTransform.DOAnchorPos(_startPoint, DurationAnimation).SetEase(Ease.OutCubic);
    }

    private void CalculateNewScreenSize() {
        float heightFactor = _camera.pixelHeight / TemplateScreenHeight;
        float widthFactor = _camera.pixelWidth / TemplateScreenWidth;
        float averageFactor = (heightFactor + widthFactor) / 2f;

        _calculatedNewHeight = _camera.pixelHeight / averageFactor;
        _calculatedNewHeight = _calculatedNewHeight / 2f;

        _calculatedNewWidth = _camera.pixelWidth / averageFactor;
        _calculatedNewWidth = _calculatedNewWidth / 2f;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Vector2 _pointOnBorderFormalGizmos;
        _pointOnBorderFormalGizmos.x = _pointOnBorderFormal.x * 2.8123f;
        _pointOnBorderFormalGizmos.y = _pointOnBorderFormal.y * 5f;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_startPoint, 0.1f);
        Gizmos.DrawWireSphere(_pointOnBorderFormalGizmos, 0.1f);
    }
#endif
}
