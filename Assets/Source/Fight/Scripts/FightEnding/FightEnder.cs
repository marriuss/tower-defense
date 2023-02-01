using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightEnder : MonoBehaviour
{
    [SerializeField] private FightStatusResolver _fightStatusResolver;
    [SerializeField] private Rewarder _rewarder;

    public event UnityAction FightEnded;

    public bool PlayerWon => _fightStatusResolver.PlayerWon;
    public FightReward Reward => _rewarder.GetReward(PlayerWon);

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
