using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class SettingsMenuView : MenuView
{
    [SerializeField] private LocalizedText _text;
    [SerializeField] private LeanPhrase _settingsPhrase;

    protected override void SetActive(bool active)
    {
        if (active)
            _text.SetPhrase(_settingsPhrase);
    }
}
