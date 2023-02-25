using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetsPool))]
public class TowerSpawner : TargetableObjectsSpawner
{
    private TowerStats _stats;

    public void Spawn(Tower prefab, int amount, TowerStats stats)
    {
        _stats = stats;
        SpawnObjects(prefab, amount);
    }

    protected override ITargetable SpawnObject<T>(T prefab, Vector2 position)
    {
        Tower tower = Instantiate(prefab as Tower, position, Quaternion.identity, transform);
        tower.SetStats(_stats);
        return tower;
    }
}
