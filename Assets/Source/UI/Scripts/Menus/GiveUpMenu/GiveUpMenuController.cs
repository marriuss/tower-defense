using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveUpMenuController : MenuController
{
    [SerializeField] private GiveUpMenuView _view;

    public void Open()
    {
        OpenMenu(_view);
    }

}
