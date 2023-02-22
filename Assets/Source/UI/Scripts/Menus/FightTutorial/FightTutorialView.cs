using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using TMPro;

public class FightTutorialView : MenuView
{
    [SerializeField] private TMP_Text _tutorialText;
    [SerializeField] private MenuExitButton _exitButton;
    [SerializeField] private LeanPhrase _phrase;
    [SerializeField] private LocalizedText _text;

    protected override void SetActive(bool active)
    {        
        if (active)
            _text.SetPhrase(_phrase);

        _tutorialText.gameObject.SetActive(active);
        _exitButton.gameObject.SetActive(active);
    }
}
