using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneLoadButton : WorkButton
{
    [SerializeField] private MapSceneLoader _loader;

    protected override void OnButtonClick()
    {
        _loader.LoadMapScene();
        SetInteractable(false);
    }
}
