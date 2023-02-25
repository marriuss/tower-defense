using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using TMPro;

public class FightEndMenuView : MenuView
{
    [SerializeField] private MapSceneLoadButton _mapLoadButton;
    [SerializeField] private LocalizedText _localizedText;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _expText;
    [SerializeField] private TMP_Text _coinsAmountText;
    [SerializeField] private TMP_Text _expAmountText;
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

    public void SetReward(FightReward reward)
    {
        _coinsAmountText.text = reward.Money.ToString();
        _expAmountText.text = reward.CardExperiencePoints.ToString();
    }

    protected override void SetActive(bool active)
    {
        if (active)
            _localizedText.SetPhrase(_playerWon ? _winText : _loseText);

        _moneyText.gameObject.SetActive(active);
        _expText.gameObject.SetActive(active);
        _coinsAmountText.gameObject.SetActive(active);
        _expAmountText.gameObject.SetActive(active);
        _mapLoadButton.gameObject.SetActive(active);
        _localizedText.gameObject.SetActive(active);
    }
}
