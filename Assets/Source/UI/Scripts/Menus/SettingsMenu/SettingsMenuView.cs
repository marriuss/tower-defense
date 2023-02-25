using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class SettingsMenuView : MenuView
{
    [SerializeField] private MenuExitButton _exitButton;
    [SerializeField] private GameObject _musicLevelBar;
    [SerializeField] private GameObject _soundsLevelBar;
    [SerializeField] private LanguagesDropdown _languagesDropdown;
    [SerializeField] private LocalizedText _text;
    [SerializeField] private LeanPhrase _settingsPhrase;

    protected override void SetActive(bool active)
    {
        if (active)
            _text.SetPhrase(_settingsPhrase);

        _text.gameObject.SetActive(true);
        _musicLevelBar.SetActive(active);
        _soundsLevelBar.SetActive(active);
        _languagesDropdown.gameObject.SetActive(active);
        _exitButton.gameObject.SetActive(active);
    }
}
