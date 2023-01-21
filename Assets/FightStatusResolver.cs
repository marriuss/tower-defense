using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightStatusResolver : MonoBehaviour
{
    [SerializeField] private FightCastle _castle;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private TargetsPool _towersPool;
    [SerializeField] private TargetsPool _enemyUnitsPool;

    private bool _enemySpawnerStopped;
    private bool _towersSpawned;

    public event UnityAction PlayerWon;
    public event UnityAction PlayerLost;

    private void Start()
    {
        _enemySpawnerStopped = false;
        _towersSpawned = false;
    }

    private void OnEnable()
    {
        _enemySpawner.StoppedSpawn += OnEnemySpawnerStopped;
        _castle.SpawnedTowers += OnTowersSpawned;
    }

    private void OnDisable()
    {
        _enemySpawner.StoppedSpawn -= OnEnemySpawnerStopped;
        _castle.SpawnedTowers -= OnTowersSpawned;
    }

    private void Update()
    {
        if (_towersPool.IsEmpty && _towersSpawned)
        {
            PlayerLost?.Invoke();
        }
        else if (_enemySpawnerStopped && _enemyUnitsPool.IsEmpty)
        {
            PlayerWon?.Invoke();
        }
    }

    private void OnEnemySpawnerStopped()
    {
        _enemySpawnerStopped = true;
    }

    private void OnTowersSpawned()
    {
        _towersSpawned = true;
    }
}
