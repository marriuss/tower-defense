using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetableObjectsSpawner : MonoBehaviour
{
    [SerializeField] private Battlefield _battlefield;

    private bool _leftSided;
    private GridCell? _cell;

    private GridCell Cell => _cell.Value;

    protected bool LeftSided => _leftSided;

    protected void SpawnObjects<T>(T prefab, int amount) where T : ITargetable
    {
        if (_cell == null)
        {
            _cell = _battlefield.GetCell(transform.position);
            _leftSided = _battlefield.CheckIsLeftSided(Cell);
        }

        int column = Cell.Column;
        FillColumn(prefab, column, amount);
    }

    protected abstract void SpawnObject<T>(T prefab, Vector2 position) where T : ITargetable;

    private void FillColumn<T>(T prefab, int column, int amount) where T : ITargetable
    {
        int rows = _battlefield.Rows;

        if (amount > rows)
        {
            FillColumn(prefab, amount - rows, _battlefield.GetNextColumn(column, _leftSided));
            amount = rows;
        }

        int centerRow = Cell.Row;

        int mod = amount % 2;
        amount -= mod;

        if (mod != 0)
            SpawnObject(prefab, centerRow, column);

        int topRow = centerRow;
        int bottomRow = centerRow;

        for (int i = 1; i <= amount / 2; i++)
        {
            topRow = _battlefield.GetNextRow(topRow, true);
            bottomRow = _battlefield.GetNextRow(bottomRow, false);
            SpawnObject(prefab, topRow, column);
            SpawnObject(prefab, bottomRow, column);
        }
    }

    private void SpawnObject<T>(T prefab, int row, int column) where T:ITargetable
    {
        GridCell cell = new(row, column);
        Vector2 position = _battlefield.GetPosition(cell);
        SpawnObject(prefab, position);
    }
}
