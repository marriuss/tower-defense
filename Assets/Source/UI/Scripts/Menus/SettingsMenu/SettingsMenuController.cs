using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuController : MenuController
{
    [SerializeField] private SettingsMenuView _view;

    public void Open()
    {
        OpenMenu(_view);
    }
}
