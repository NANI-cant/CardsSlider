using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardVisualizator : MonoBehaviour {
    [SerializeField] private Vector2 gridCenter;
    [SerializeField] private float cellSize;
    [SerializeField] private SpriteRenderer figureTemplate;
    [Header("Debug")]
    [SerializeField] private Color debugColor;
    [Range(1, 9)] [SerializeField] private int debugCellsCount;
    [SerializeField] private float debugCrosshairSize = 0.5f;
    [SerializeField] private List<Vector2> debugPositions;

    private List<FigureData> figures;

    public void Visualize(List<FigureData> figures) {
        this.figures = figures;
        List<Vector2> positions = CalculateGrid(figures.Count);
        for (int i = 0; i < figures.Count; i++) {
            SpriteRenderer spriteRenderer = Instantiate(figureTemplate, positions[i], Quaternion.identity, transform);
            spriteRenderer.sprite = figures[i].Sprite;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = debugColor;
        Gizmos.DrawLine(transform.TransformPoint(gridCenter), transform.TransformPoint(gridCenter) + new Vector3(1, 0, 0) * debugCrosshairSize);
        Gizmos.DrawLine(transform.TransformPoint(gridCenter), transform.TransformPoint(gridCenter) + new Vector3(-1, 0, 0) * debugCrosshairSize);
        Gizmos.DrawLine(transform.TransformPoint(gridCenter), transform.TransformPoint(gridCenter) + new Vector3(0, 1, 0) * debugCrosshairSize);
        Gizmos.DrawLine(transform.TransformPoint(gridCenter), transform.TransformPoint(gridCenter) + new Vector3(0, -1, 0) * debugCrosshairSize);

        List<Vector2> cellPositions = debugPositions = CalculateGrid(figures == null ? debugCellsCount : figures.Count);
        foreach (var cellPos in cellPositions) {
            Gizmos.DrawWireCube(cellPos, new Vector2(cellSize, cellSize));
        }
    }

    private List<Vector2> CalculateGrid(int cellsCount) {
        List<Vector2> positions = new List<Vector2>();

        Vector2 startPos = transform.TransformPoint(gridCenter);
        int remaindCellsCount = cellsCount;
        for (int i = 1; i > -1; i++) {
            if (remaindCellsCount <= 0) { break; }
            int currentCellsCount = remaindCellsCount < i * 2 ? remaindCellsCount : i;

            for (int j = 0; j < currentCellsCount; j++) {
                Vector2 curPos = startPos;
                curPos -= new Vector2((float)currentCellsCount * cellSize / 2 - cellSize / 2 - j * cellSize, -((i - 1) * cellSize));
                positions.Add(curPos);
            }

            remaindCellsCount -= i * 2;
        }

        float yOffset = cellSize / 2;
        float yPadding = positions[positions.Count - 1].y - positions[0].y;
        if (positions.Count > cellsCount / 2) {
            yOffset = 0;
        }
        for (int i = 0; i < positions.Count; i++) {

            positions[i] -= new Vector2(0f, yPadding + yOffset);
        }

        int currentPosCount = positions.Count;
        for (int i = 0; i < currentPosCount; i++) {
            Vector2 localPos = positions[i] - gridCenter - (Vector2)transform.position;
            Vector2 invercePos = gridCenter + (Vector2)transform.position + localPos * -1f;
            if (!positions.Contains(invercePos)) {
                positions.Add(invercePos);
            }
        }

        return positions;
    }
}
