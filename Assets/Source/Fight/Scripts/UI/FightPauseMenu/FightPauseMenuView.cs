using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPauseMenuView : MenuView
{
    [SerializeField] private MapSceneLoadButton _button;

    protected override void SetActive(bool active)
    {
        _button.gameObject.SetActive(active);
    }
}
