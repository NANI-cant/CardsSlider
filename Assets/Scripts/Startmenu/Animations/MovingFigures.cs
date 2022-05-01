using DG.Tweening;
using UnityEngine;
using Zenject;


public class MovingFigures : MonoBehaviour {

    [SerializeField] private Vector2 _endPointFormal;

    private RectTransform _rectTransform;
    private Vector2 _startPoint;
    private float _durationAnimation = 0.5f;
    private Camera _camera;
    private Vector2 _endPoint;

    private float _calculatedNewHeight;
    private float _calculatedNewWidth;

    [Inject]
    public void Construct(Camera camera){
        _camera = camera;
    }

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        
    }

    private void Start() {
        _startPoint = _rectTransform.localPosition;
        // Calculate();
        // MoveToOtherPoint();
        // MoveToAnotherPoint();
    }

    private void Update() {
        // Calculate();
        // MoveToOtherPoint();
        // MoveToAnotherPoint();
    }

    public void ToBorder(){
        Calculate();
        MoveToOtherPoint();
    }

    public void ToStartPosition() {
        Calculate();
        MoveToAnotherPoint();
    }


    private void Calculate(){
        float heightFactor = _camera.pixelHeight / 1920f;
        float widthFactor = _camera.pixelWidth / 1080f;
        float averageFactor = (heightFactor + widthFactor) / 2f;
        _calculatedNewHeight = _camera.pixelHeight / averageFactor;
        _calculatedNewHeight = _calculatedNewHeight / 2f;

        _calculatedNewWidth = _camera.pixelWidth / averageFactor;
        _calculatedNewWidth = _calculatedNewWidth / 2f;
    }

    private void MoveToOtherPoint() {
        _endPoint.x = _calculatedNewWidth * _endPointFormal.x;
        _endPoint.y = _calculatedNewHeight * _endPointFormal.y;
        //Debug.Log(_endPoint);
        _rectTransform.DOAnchorPos(_endPoint, _durationAnimation);
       
    }

    private void MoveToAnotherPoint(){
        _rectTransform.DOAnchorPos(_startPoint, _durationAnimation);
    }

    // private void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.cyan;
    //     Gizmos.DrawWireSphere(_startPoint, 0.1f);
    //     Gizmos.DrawWireSphere(_endPoint, 0.1f);
    // }
}
