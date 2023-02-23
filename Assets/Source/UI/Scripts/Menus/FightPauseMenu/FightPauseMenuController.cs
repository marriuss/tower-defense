using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPauseMenuController : MenuController
{
    [SerializeField] private FightPauseMenuView _view;

    //private void OnApplicationFocus(bool focus)
    //{
    //    if (focus == false && MenuGroup.GameIsActive)
    //        OpenPauseMenu();
    //}

    public void OpenPauseMenu()
    {
        OpenMenu(_view);
    }

}
