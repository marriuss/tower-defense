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
    private bool _fightEnded;

    public event UnityAction<bool> PlayerWon;

    private void Start()
    {
        _fightEnded = false;
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
        if (_fightEnded == false)
        {
            if (_enemySpawnerStopped && _enemyUnitsPool.IsEmpty)
            {
                EndFight(true);
            }
            else if (_towersPool.IsEmpty && _towersSpawned)
            {
                EndFight(false);
            }
        }
    }

    private void EndFight(bool playerWon)
    {
        _fightEnded = true;
        PlayerWon?.Invoke(playerWon);
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
