using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitSpawner : MonoBehaviour
{
    [SerializeField] private Battlefield _battlefield;

    private bool _leftSided;
    private GridCell? _cell;

    protected void SpawnUnit(Unit unitPrefab, int amount)
    {
        if (_cell == null)
        {
            _cell = _battlefield.GetCell(transform.position);
            _leftSided = _battlefield.CheckIsLeftSided(_cell.Value);
        }

        int column = _cell.Value.Column;
        FillColumn(column, amount, unitPrefab);
    }

    private void FillColumn(int column, int amount, Unit unitPrefab)
    {
        int rows = _battlefield.Rows;

        if (amount > rows)
        {
            FillColumn(_battlefield.GetNextColumn(column, _leftSided), amount - rows, unitPrefab);
            amount = rows;
        }

        int centerRow = rows / 2;
        int mod = amount % 2;
        amount -= mod;

        if (mod != 0)
            SpawnUnit(unitPrefab, column, centerRow);

        for (int i = 1; i <= amount / 2; i++)
        {
            SpawnUnit(unitPrefab, _battlefield.GetNextRow(centerRow, true), column);
            SpawnUnit(unitPrefab, _battlefield.GetNextRow(centerRow, false), column);
        }
    }

    private void SpawnUnit(Unit unitPrefab, int row, int column)
    {
        GridCell cell = new(row, column);
        Vector2 position = _battlefield.GetPosition(cell);
        
        Unit unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);
        unit.SetSide(_leftSided);
    }
}
