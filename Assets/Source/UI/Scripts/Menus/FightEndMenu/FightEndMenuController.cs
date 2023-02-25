using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEndMenuController : MenuController
{
    [SerializeField] private FightRewardApplier _fightRewardApplier;
    [SerializeField] private FightEnder _fightEnder;
    [SerializeField] private FightEndMenuView _view;
    [SerializeField] private LevelsPool _levelsPool;

    private const float OpenDelay = 2f;

    private void OnEnable()
    {
        _fightEnder.FightEnded += OnFightEnded;
    }

    private void OnDisable()
    {
        _fightEnder.FightEnded -= OnFightEnded;
    }

    private void OnFightEnded()
    {
        FightReward reward = _fightEnder.Reward;
        bool playerWon = _fightEnder.PlayerWon;
        _fightRewardApplier.ApplyReward(reward);

        if (playerWon)
            _levelsPool.SetLastLevelId(_levelsPool.LastLevelId + 1);

        _view.SetReward(reward);
        _view.SetPlayerStatus(playerWon);
        MenuGroup.OpenRaycastTarget();
        StartCoroutine(OpenMenu(OpenDelay));
    }

    private IEnumerator OpenMenu(float delay) 
    {
        WaitForSeconds wait = new(delay);
        yield return wait;

        OpenMenu(_view);
    }
}
