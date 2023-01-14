using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetsPool))]
public abstract class UnitSpawner : TargetableObjectsSpawner
{
    private const int MinSpawnAmount = 1;
    private const int MaxSpawnAmount = 5;

    private int _spawnAmountRange = MaxSpawnAmount - MinSpawnAmount;
    private float _unitValueRange = Unit.MaxValue - Unit.MinValue;
    private List<Unit> _despawnedUnitsPool = new();
    private TargetsPool _spawnedUnitsPool;

    private void Awake()
    {
        _spawnedUnitsPool = GetComponent<TargetsPool>();
    }

    protected void Spawn(Unit unitPrefab)
    {
        int amount = CalculateSpawnAmount(unitPrefab.GetValue());
        SpawnObjects(unitPrefab, amount);
    }

    protected override void SpawnObject<T>(T prefab, Vector2 position)
    {
        Unit unitPrefab = prefab as Unit;
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
        unit.TurnSide(!LeftSided);
    }

    private int CalculateSpawnAmount(int unitValue) => Mathf.RoundToInt(_spawnAmountRange * (Unit.MaxValue - unitValue) / _unitValueRange + MinSpawnAmount);

    private void OnUnitDied(ITargetable target)
    {
        Unit unit = target as Unit;
        unit.Died -= OnUnitDied;
        unit.Despawn();
        _spawnedUnitsPool.RemoveObject(unit);
        _despawnedUnitsPool.Add(unit);
    }
}
