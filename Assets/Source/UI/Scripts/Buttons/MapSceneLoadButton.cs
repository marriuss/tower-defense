using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneLoadButton : WorkButton
{
    [SerializeField] private MapSceneLoader _loader;
    [SerializeField] private FightEnder _fightEnder;

    protected override void OnButtonClick()
    {
        FightReward fightReward = _fightEnder.Reward;
        _loader.LoadMapScene(fightReward);
        SetInteractable(false);
    }
}
