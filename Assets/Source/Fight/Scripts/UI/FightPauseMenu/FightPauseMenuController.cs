using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPauseMenuController : MenuController
{
    [SerializeField] private FightPauseMenuView _view;

    public void OpenPauseMenu()
    {
        OpenMenu(_view);
    }

}
