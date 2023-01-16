using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetsPool))]
public class TowerSpawner : TargetableObjectsSpawner
{
    private TargetsPool _pool;

    private void Awake()
    {
        _pool = GetComponent<TargetsPool>();
    }

    public void AddMainTower(Tower mainTower)
    {
        AddToPool(mainTower);
    }

    public void Spawn(Tower prefab, int amount)
    {
        SpawnObjects(prefab, amount);
    }

    protected override void SpawnObject<T>(T prefab, Vector2 position)
    {
        Tower tower = Instantiate(prefab as Tower, position, Quaternion.identity, transform);
        AddToPool(tower);
    }

    private void AddToPool(Tower tower)
    {
        StartCoroutine(AddWhenPoolInitialized(tower));
    }

    private void OnTowerDied(ITargetable targetableObject)
    {
        Tower tower = targetableObject as Tower;
        tower.Died -= OnTowerDied;
        _pool.RemoveObject(tower);
    }

    private IEnumerator AddWhenPoolInitialized(Tower tower)
    {
        yield return _pool != null;

        _pool.AddObject(tower);
        tower.Died += OnTowerDied;
    }
}
