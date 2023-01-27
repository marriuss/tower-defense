using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class FightEndMenuView : MenuView
{
    [SerializeField] private LocalizedText _localizedText;
    [SerializeField] private LeanPhrase _winText;
    [SerializeField] private LeanPhrase _loseText;

    private bool _playerWon;

    private void Start()
    {
        _playerWon = false;
    }

    public void SetPlayerStatus(bool playerWon)
    {
        _playerWon = playerWon;
    }

    protected override void SetActive(bool active)
    {
        if (active)
            _localizedText.SetPhrase(_playerWon ? _winText : _loseText);

        _localizedText.gameObject.SetActive(active);
    }
}
