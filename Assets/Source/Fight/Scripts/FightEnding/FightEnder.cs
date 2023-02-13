using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightEnder : MonoBehaviour
{
    [SerializeField] private FightStatusResolver _fightStatusResolver;
    [SerializeField] private RewardAccounter _rewardAccounter;

    public event UnityAction FightEnded;

    public bool PlayerWon => _fightStatusResolver.PlayerWon;
    public FightReward Reward => _rewardAccounter.GetReward(PlayerWon);

    private void OnEnable()
    {
        _fightStatusResolver.FightStatusResolved += OnFightStatusResolved;
    }

    private void OnDisable()
    {
        _fightStatusResolver.FightStatusResolved -= OnFightStatusResolved;
    }

    private void OnFightStatusResolved()
    {
        FightEnded?.Invoke();
    }
}
