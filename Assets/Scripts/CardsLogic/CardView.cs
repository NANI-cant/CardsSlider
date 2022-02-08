using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour {
    [SerializeField] private Vector2 _gridCenter;
    [SerializeField] private float _cellSize;
    [SerializeField] private SpriteRenderer _figureTemplate;

    [Header("Debug")]
    [SerializeField] private Color _debugColor;
    [Range(1, 9)] [SerializeField] private int _debugCellsCount;
    [SerializeField] private float _debugCrosshairSize = 0.5f;
    [SerializeField] private List<Vector2> _debugPositions;

    private List<FigureData> _figures;

    private void OnValidate() {
        if (_cellSize < 0) _cellSize = 0;
    }

    public void Visualize(List<FigureData> figures) {
        _figures = figures;
        List<Vector2> positions = CalculateGrid(figures.Count);
        for (int i = 0; i < figures.Count; i++) {
            SpriteRenderer spriteRenderer = Instantiate(_figureTemplate, positions[i], Quaternion.identity, transform);
            spriteRenderer.sprite = figures[i].Sprite;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = _debugColor;
        Gizmos.DrawLine(transform.TransformPoint(_gridCenter), transform.TransformPoint(_gridCenter) + new Vector3(1, 0, 0) * _debugCrosshairSize);
        Gizmos.DrawLine(transform.TransformPoint(_gridCenter), transform.TransformPoint(_gridCenter) + new Vector3(-1, 0, 0) * _debugCrosshairSize);
        Gizmos.DrawLine(transform.TransformPoint(_gridCenter), transform.TransformPoint(_gridCenter) + new Vector3(0, 1, 0) * _debugCrosshairSize);
        Gizmos.DrawLine(transform.TransformPoint(_gridCenter), transform.TransformPoint(_gridCenter) + new Vector3(0, -1, 0) * _debugCrosshairSize);

        List<Vector2> cellPositions = _debugPositions = CalculateGrid(_figures == null ? _debugCellsCount : _figures.Count);
        foreach (var cellPos in cellPositions) {
            Gizmos.DrawWireCube(cellPos, new Vector2(_cellSize, _cellSize));
        }
    }

    private List<Vector2> CalculateGrid(int cellsCount) {
        List<Vector2> positions = new List<Vector2>();

        Vector2 startPos = transform.TransformPoint(_gridCenter);
        int remaindCellsCount = cellsCount;
        for (int i = 1; i > -1; i++) {
            if (remaindCellsCount <= 0) { break; }
            int currentCellsCount = remaindCellsCount < i * 2 ? remaindCellsCount : i;

            for (int j = 0; j < currentCellsCount; j++) {
                Vector2 curPos = startPos;
                curPos -= new Vector2((float)currentCellsCount * _cellSize / 2 - _cellSize / 2 - j * _cellSize, -((i - 1) * _cellSize));
                positions.Add(curPos);
            }

            remaindCellsCount -= i * 2;
        }

        float yOffset = _cellSize / 2;
        float yPadding = positions[positions.Count - 1].y - positions[0].y;
        if (positions.Count > cellsCount / 2) {
            yOffset = 0;
        }
        for (int i = 0; i < positions.Count; i++) {

            positions[i] -= new Vector2(0f, yPadding + yOffset);
        }

        int currentPosCount = positions.Count;
        for (int i = 0; i < currentPosCount; i++) {
            Vector2 localPos = positions[i] - _gridCenter - (Vector2)transform.position;
            Vector2 invercePos = _gridCenter + (Vector2)transform.position + localPos * -1f;
            if (!positions.Contains(invercePos)) {
                positions.Add(invercePos);
            }
        }

        return positions;
    }
}
