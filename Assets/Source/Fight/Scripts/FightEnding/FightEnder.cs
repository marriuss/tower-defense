using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightEnder : MonoBehaviour
{
    [SerializeField] private FightStatusResolver _fightStatusResolver;
    [SerializeField] private Rewarder _rewarder;

    public event UnityAction FightEnded;

    public FightReward Reward { get; private set; }

    private void OnEnable()
    {
        _fightStatusResolver.PlayerWon += OnFightEnded;
    }

    private void OnDisable()
    {
        _fightStatusResolver.PlayerWon -= OnFightEnded;
    }

    private void OnFightEnded(bool playerWon)
    {
        Reward = _rewarder.GetReward(playerWon);
        FightEnded?.Invoke();
    }
}
