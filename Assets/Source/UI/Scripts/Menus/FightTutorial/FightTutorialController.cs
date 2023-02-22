using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTutorialController : MenuController
{
    [SerializeField] private FightTutorialView _view;

    public void Open()
    {
        OpenMenu(_view);
    }
}
