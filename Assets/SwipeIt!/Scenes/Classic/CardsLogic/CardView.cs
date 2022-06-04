using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour {
    [SerializeField] private Vector2 _gridCenter;
    [Min(0)]
    [SerializeField] private Vector2 _cellSize;
    [SerializeField] private SpriteRenderer _figureTemplate;

    [Header("Debug")]
    [SerializeField] private Color _debugColor;
    [Range(1, 8)][SerializeField] private int _debugCellsCount;
    [SerializeField] private float _debugCrosshairSize = 0.5f;
    [SerializeField] private List<Vector2> _debugPositions;

    private const int MAINCOLUMNSCOUNT = 2;
    private const int TAILCOLUMNSCOUNT = 1;

    private List<FigureData> _figures;

    public void Visualize(List<FigureData> figures) {
        _figures = figures;
        List<Vector2> positions = CalculateGrid(figures.Count);
        for (int i = 0; i < figures.Count; i++) {
            SpriteRenderer spriteRenderer = Instantiate(_figureTemplate, positions[i], Quaternion.identity, transform);
            spriteRenderer.sprite = figures[i].Sprite;
        }
    }

    private List<Vector2> CalculateGrid(int cellsCount) {
        List<Vector2> positions = new List<Vector2>();

        int mainRows = cellsCount / MAINCOLUMNSCOUNT;
        int tailRows = cellsCount % MAINCOLUMNSCOUNT;

        Vector2 pointer = Vector2.zero;
        pointer = CalculateMainRows(positions, mainRows, pointer);
        pointer = CalculateTailRows(positions, tailRows, pointer);

        Vector2 centerOfMass = GetCenterOfMass(positions);

        TranslateToGridCenter(positions, centerOfMass);
        ToGlobal(positions);

        return positions;
    }

    private void ToGlobal(List<Vector2> positions) {
        for (int i = 0; i < positions.Count; i++) {
            positions[i] += (Vector2)transform.position;
        }
    }

    private void TranslateToGridCenter(List<Vector2> positions, Vector2 centerOfMass) {
        Vector2 tranlsationToGridCenter = _gridCenter - centerOfMass;
        for (int i = 0; i < positions.Count; i++) {
            positions[i] += tranlsationToGridCenter;
        }
    }

    private static Vector2 GetCenterOfMass(List<Vector2> positions) {
        Vector2 positionsSum = Vector2.zero;
        foreach (var position in positions) {
            positionsSum += position;
        }
        if (positions.Count % MAINCOLUMNSCOUNT == 1) {
            positionsSum += positions[positions.Count - 1];
        }
        Vector2 centerOfMass = positionsSum / (positions.Count + positions.Count % MAINCOLUMNSCOUNT);
        return centerOfMass;
    }

    private Vector2 CalculateMainRows(List<Vector2> positions, int mainRows, Vector2 pointer) {
        for (int row = 0; row < mainRows; row++) {
            for (int column = 0; column < MAINCOLUMNSCOUNT; column++) {
                positions.Add(pointer);

                pointer.x += _cellSize.x;
            }
            pointer.x = 0;
            pointer.y -= _cellSize.y;
        }

        return pointer;
    }

    private Vector2 CalculateTailRows(List<Vector2> positions, int tailRows, Vector2 pointer) {
        pointer.x += _cellSize.x / MAINCOLUMNSCOUNT;
        for (int row = 0; row < tailRows; row++) {
            for (int column = 0; column < TAILCOLUMNSCOUNT; column++) {
                positions.Add(pointer);

                pointer.x += _cellSize.x;
            }
            pointer.x = _cellSize.x / MAINCOLUMNSCOUNT;
            pointer.y -= _cellSize.x;
        }

        return pointer;
    }

    private void OnDrawGizmos() {
        Gizmos.color = _debugColor;

        List<Vector2> cellPositions = _debugPositions = CalculateGrid(_figures == null ? _debugCellsCount : _figures.Count);
        foreach (var cellPos in cellPositions) {
            Gizmos.DrawWireCube(cellPos, _cellSize);
            DrawCrossHairGizmos(cellPos);
        }
    }

    private void DrawCrossHairGizmos(Vector2 point) {
        Gizmos.DrawLine(point, point + Vector2.right * _debugCrosshairSize);
        Gizmos.DrawLine(point, point + Vector2.left * _debugCrosshairSize);
        Gizmos.DrawLine(point, point + Vector2.up * _debugCrosshairSize);
        Gizmos.DrawLine(point, point + Vector2.down * _debugCrosshairSize);
    }
}
