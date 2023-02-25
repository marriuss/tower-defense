using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressSaver : MonoBehaviour
{
    [SerializeField] private PlayerProgressStorage _storage;
    [SerializeField] private Player _player;
    [SerializeField] private LevelsPool _levelsPool;

    private void OnEnable()
    {
        _player.Balance.MoneyCountChanged += OnBalanceChanged;
        _player.Castle.StatsChanged += OnCastleStatsChanged;
        _player.Deck.CardsChanged += OnCardsChanged;
        _levelsPool.LastLevelChanged += OnLastLevelChanged;
    }

    private void OnDisable()
    {
        _player.Balance.MoneyCountChanged -= OnBalanceChanged;
        _player.Castle.StatsChanged -= OnCastleStatsChanged;
        _player.Deck.CardsChanged -= OnCardsChanged;
        _levelsPool.LastLevelChanged -= OnLastLevelChanged;
    }

    private void OnBalanceChanged(int _)
    {
        _storage.SaveBalance();
    }

    private void OnCastleStatsChanged()
    {
        _storage.SaveCastleStats();
    }

    private void OnCardsChanged()
    {
        _storage.SaveCardsProgress();
    }

    private void OnLastLevelChanged()
    {
        _storage.SaveLastLevelId();
    }
}
