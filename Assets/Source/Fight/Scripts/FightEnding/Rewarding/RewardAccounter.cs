using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAccounter : MonoBehaviour
{
    [SerializeField] private TargetsPool _enemiesPool;
    [SerializeField] private CardStack _cardStack;

    private int _money;
    private int _totalExperiencePoints;
    private int _cardExperiencePoints;

    private int _uniqueCards => _cardStack.UniqueCardsAmount;

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
        _money = money;
    }

    public FightReward GetReward(bool playerWon)
    {
        int money = playerWon ? _money : 0;
        return new FightReward(money, _cardExperiencePoints);
    }

    private void OnEnemyRemoved(ITargetable targetableObject) 
    {
        EnemyUnit enemy = targetableObject as EnemyUnit;
        _totalExperiencePoints += enemy.Stats.Value;
        _cardExperiencePoints = _uniqueCards == 0 ? 0 : _totalExperiencePoints / _uniqueCards;
    }
}
