using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : WorkButton
{
    [SerializeField] private SettingsMenuController _controller;

    protected override void OnButtonClick()
    {
        _controller.Open();
    }
}
