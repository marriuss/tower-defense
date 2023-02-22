using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTutorialController : MenuController
{
    [SerializeField] private FightTutorialView _view;

    private void Start()
    {
        if (PlayerProgressStorage.HasSavings == false && FightSceneLoader.SceneLoadingCount == 1)
            Open();
    }

    public void Open()
    {
        OpenMenu(_view);
    }
}
