using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExitButton : WorkButton
{
    [SerializeField] private MenuGroup _menuGroup;

    protected override void OnButtonClick()
    {
        _menuGroup.CloseLastMenu();
    }
}
