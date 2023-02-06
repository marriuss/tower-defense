using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreYouSureGiveUpButton : WorkButton
{
    [SerializeField] private GiveUpMenuController _controller;

    protected override void OnButtonClick()
    {
        _controller.Open();
    }
}
