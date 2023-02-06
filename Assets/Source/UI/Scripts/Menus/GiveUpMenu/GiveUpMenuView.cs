using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Localization;

public class GiveUpMenuView : MenuView
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GiveUpButton _giveUpButton;
    [SerializeField] private MenuExitButton _menuExitButton;
    [SerializeField] private LocalizedText _localizedText;
    [SerializeField] private LeanPhrase _areUSurePhrase;

    protected override void SetActive(bool active)
    {
        if (active)
            _localizedText.SetPhrase(_areUSurePhrase);

        _text.gameObject.SetActive(active);
        _giveUpButton.gameObject.SetActive(active);
        _menuExitButton.gameObject.SetActive(active);
    }
}
