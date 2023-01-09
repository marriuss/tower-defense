using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ProgressLoader _progressLoader;

    private Deck _deck;
    private CastleStats _castleStats;
    private Balance _balance;

    private void Awake()
    {
        _deck = new Deck();
        _castleStats = new CastleStats();
        _balance = new Balance();
    }

    private void OnEnable()
    {
        _progressLoader.ProgressLoaded += OnProgressLoaded;
    }

    private void OnDisable()
    {
        _progressLoader.ProgressLoaded -= OnProgressLoaded;
    }

    private void OnProgressLoaded(PlayerProgress progress)
    {
        _balance.AddMoney(progress.Money);
    }
}
