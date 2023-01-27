using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuController : MonoBehaviour
{
    [SerializeField] private MenuGroup _menuGroup;

    protected void OpenMenu(MenuView view)
    {
        _menuGroup.Open(view);
    }

    protected void CloseMenu(MenuView view)
    {
        _menuGroup.Close(view);
    }
}
