using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAccounter : MonoBehaviour
{
    [SerializeField] private TargetsPool _enemiesPool;
    
    public int Money { get; private set; }
    public int TotalExperiencePoints { get; private set; }

    private void OnEnable()
    {
        _enemiesPool.RemovedObject += OnEnemyRemoved;
    }

    private void OnDisable()
    {
        _enemiesPool.RemovedObject -= OnEnemyRemoved;
    }

    public void SetMoneyReward(int money)
    {
        Money = money;
    }

    private void OnEnemyRemoved(ITargetable targetableObject) 
    {
        EnemyUnit enemy = targetableObject as EnemyUnit;
        TotalExperiencePoints += CalculateExperiencePoints(enemy);
    }

    private int CalculateExperiencePoints(Unit unit)
    {
        // TODO
        return 1;
    }
}
