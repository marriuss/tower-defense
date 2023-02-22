using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightHelpButton : WorkButton
{
    [SerializeField] private FightTutorialController _controller;

    protected override void OnButtonClick()
    {
        _controller.Open();
    }
}
