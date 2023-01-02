using UnityEngine;
using System;
using System.Collections.Generic;

public class Battlefield : MonoBehaviour
{
    [SerializeField, Min(1)] private Vector2 _battlefieldSize;
    [SerializeField, Min(1)] private int _rows;
    [SerializeField, Min(1)] private int _columns;

    private Rect _battlefieldRect;
    private float _cellWidth;
    private float _cellHeight;

    public int Rows => _rows;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f);
        Vector2 size = new Vector2(_cellWidth, _cellHeight);
        Vector2 center;

        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {
                center = GetCenter(row, column);
                Gizmos.DrawWireCube(center, size);
            }
        }
    }

    private void OnValidate()
    {
        Vector2 position = transform.position;
        _battlefieldRect = new Rect(position - _battlefieldSize / 2, _battlefieldSize);
        _cellWidth = _battlefieldRect.size.x / _columns;
        _cellHeight = _battlefieldRect.size.y / _rows;
    }
    
    public GridCell GetCell(Vector2 position)
    {
        if (CheckInBattlefield(position) == false)
            throw new ArgumentException("Object doesn't belong to battlefield");

        Vector2 subtraction = position - _battlefieldRect.center;

        float xDistance = Mathf.Abs(subtraction.x);
        int column = Mathf.FloorToInt(xDistance / _cellWidth);

        float yDistance = Mathf.Abs(subtraction.y);
        int row = Mathf.FloorToInt(yDistance / _cellHeight);

        return new GridCell(row, column);
    }

    public Vector2 GetPosition(GridCell cell)
    {
        if (CheckInBattlefield(cell) == false)
            throw new ArgumentException("Object doesn't belong to battlefield");

        return GetCenter(cell.Row, cell.Column);
    }

    public int GetNextRow(int row, bool above)
    {
        return above ? row + 1 : row - 1;
    }

    public int GetNextColumn(int column, bool right)
    {
        return right ? column + 1 : column - 1;
    }

    public bool CheckIsLeftSided(GridCell cell)
    {
        return cell.Column < _columns / 2;
    }

    private Vector2 GetCenter(int row, int column)
    {
        return new(_battlefieldRect.xMin + _cellWidth * (0.5f + column), _battlefieldRect.yMin + _cellHeight * (0.5f + row));
    }

    private bool CheckInBattlefield(Vector2 point) => _battlefieldRect.Contains(point);

    private bool CheckInBattlefield(GridCell cell) 
    {
        int row = cell.Row;
        int column = cell.Column;

        return 0 < row && row < _rows && 0 < column && column < _columns;
    }
}
