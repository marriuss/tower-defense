using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetsPool))]
public abstract class UnitSpawner : MonoBehaviour
{
    [SerializeField] private Battlefield _battlefield;

    private const int MinSpawnAmount = 1;
    private const int MaxSpawnAmount = 5;

    private bool _leftSided;
    private GridCell? _cell;
    private int _spawnAmountRange = MaxSpawnAmount - MinSpawnAmount;
    private float _unitValueRange = Unit.MaxValue - Unit.MinValue;
    private List<Unit> _despawnedUnitsPool = new();
    private TargetsPool _spawnedUnitsPool;

    private void Awake()
    {
        _spawnedUnitsPool = GetComponent<TargetsPool>();
    }

    protected void SpawnUnit(Unit unitPrefab)
    {
        if (_cell == null)
        {
            _cell = _battlefield.GetCell(transform.position);
            _leftSided = _battlefield.CheckIsLeftSided(_cell.Value);
        }

        int column = _cell.Value.Column;
        int amount = CalculateSpawnAmount(unitPrefab.GetValue());
        FillColumn(column, amount, unitPrefab);
    }

    private int CalculateSpawnAmount(int unitValue) => Mathf.RoundToInt(_spawnAmountRange * (Unit.MaxValue - unitValue) / _unitValueRange + MinSpawnAmount);

    private void FillColumn(int column, int amount, Unit unitPrefab)
    {
        int rows = _battlefield.Rows;

        if (amount > rows)
        {
            FillColumn(_battlefield.GetNextColumn(column, _leftSided), amount - rows, unitPrefab);
            amount = rows;
        }

        int centerRow = _cell.Value.Row;

        int mod = amount % 2;
        amount -= mod;

        if (mod != 0)
            SpawnUnit(unitPrefab, centerRow, column);

        int topRow = centerRow;
        int bottomRow = centerRow;

        for (int i = 1; i <= amount / 2; i++)
        {
            topRow = _battlefield.GetNextRow(topRow, true);
            bottomRow = _battlefield.GetNextRow(bottomRow, false);

            SpawnUnit(unitPrefab, topRow, column);
            SpawnUnit(unitPrefab, bottomRow, column);
        }
    }

    private void SpawnUnit(Unit unitPrefab, int row, int column)
    {
        GridCell cell = new(row, column);
        Vector2 position = _battlefield.GetPosition(cell);

        Unit unit = _despawnedUnitsPool.Find(unit => unit.Stats.Name == unitPrefab.Stats.Name);

        if (unit == null)
        {
            unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);
        }
        else
        {
            _despawnedUnitsPool.Remove(unit);
            unit.MoveTo(position);
        }

        unit.Spawn();
        _spawnedUnitsPool.AddObject(unit);
        unit.Died += OnUnitDied;
        unit.TurnSide(!_leftSided);
    }

    private void OnUnitDied(ITargetable target)
    {
        Unit unit = target as Unit;
        unit.Died -= OnUnitDied;
        unit.Despawn();
        _spawnedUnitsPool.RemoveObject(unit);
        _despawnedUnitsPool.Add(unit);
    }
}
