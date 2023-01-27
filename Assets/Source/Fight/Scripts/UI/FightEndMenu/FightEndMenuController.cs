using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEndMenuController : MenuController
{
    [SerializeField] private FightEnder _fightEnder;
    [SerializeField] private FightEndMenuView _view;

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
        _view.SetPlayerStatus(_fightEnder.PlayerWon);
        OpenMenu(_view);
    }
}
