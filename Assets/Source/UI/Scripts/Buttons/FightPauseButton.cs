using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPauseButton : WorkButton
{
    [SerializeField] private FightPauseMenuController _controller;

    protected override void OnButtonClick()
    {
        _controller.OpenPauseMenu();
    }
}
