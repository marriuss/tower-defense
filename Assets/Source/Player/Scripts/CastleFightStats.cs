using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleFightStats
{
    private float _towerHealthFraction;

    public int Health { get; private set; }
    public int AdditionalTowers { get; private set; }
    public float TowerHealthFraction
    {
        get
        {
            return _towerHealthFraction;
        }
        set
        {
            value = Mathf.Clamp01(value);
            _towerHealthFraction = value;
        }
    }

    public CastleFightStats(int health, int towersAmount, float towerHealthFraction)
    {
        Health = health;
        AdditionalTowers = towersAmount;
        TowerHealthFraction = towerHealthFraction;
    }

    public TowerStats CalculateTowerStats()
    {
        int towerHealth = Mathf.CeilToInt(Health * TowerHealthFraction);

        return new TowerStats(towerHealth);
    }
}
