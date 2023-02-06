using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveUpButton : WorkButton
{
    [SerializeField] private FightStatusResolver _fightStatusResolver;
    [SerializeField] private MenuGroup _menuGroup;

    protected override void OnButtonClick()
    {
        _menuGroup.CloseMenus();
        _fightStatusResolver.MakePlayerLose();
    }
}
