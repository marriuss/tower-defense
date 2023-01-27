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

    private bool _fightEnded;

    public event UnityAction<bool> PlayerWon;

    private void Start()
    {
        _fightEnded = false;
    }

    private void Update()
    {
        if (_fightEnded == false)
        {
            if (_enemySpawner.EnemiesSpawned && _enemyUnitsPool.IsEmpty)
            {
                EndFight(true);
            }
            else if (_towersPool.IsEmpty && _castle.TowersSpawned)
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
}
