using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class FightPauseMenuView : MenuView
{
    [SerializeField] private SettingsButton _settingsButton;
    [SerializeField] private MenuExitButton _menuExitButton;
    [SerializeField] private MapSceneLoadButton _mapSceneLoadButton;
    [SerializeField] private LocalizedText _text;
    [SerializeField] private LeanPhrase _pauseText;

    protected override void SetActive(bool active)
    {
        if (active)
            _text.SetPhrase(_pauseText);

        _settingsButton.gameObject.SetActive(active);
        _menuExitButton.gameObject.SetActive(active);
        _mapSceneLoadButton.gameObject.SetActive(active);
    }
}
