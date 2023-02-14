using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Lean.Localization;

[CreateAssetMenu(fileName = "New UnitStats", menuName = "SO/UnitStats", order = 51)]
public class UnitStats : ScriptableObject
{
    public const int MinValue = 1;
    public const int MaxValue = 15;
    public const int ValueRange = MaxValue - MinValue;

    [SerializeField] private string _name;
    [SerializeField, Range(1, MaxHealth)] private int _health;
    [SerializeField, Range(1, MaxArmor)] private int _armor;
    [SerializeField, Range(MinIntStat, MaxDamage)] private int _damage;
    [SerializeField, Range(MinFloatStat, MaxSpeed)] private float _speed;
    [SerializeField, Range(MinFloatStat, MaxAttackDelay)] private float _attackDelay;
    [SerializeField, Range(MinFloatStat, MaxRange)] private float _attackRange;

    private const int MinIntStat = 1;
    private const int MaxArmor = 30;
    private const int MaxHealth = 50;
    private const int MaxDamage = 40;
    private const float MinFloatStat = 0.1f;
    private const float MaxSpeed = 3;
    private const float MaxAttackDelay = 2f;
    private const float MaxRange = 10f;

    public string Name => _name;
    public int Health => _health;
    public int Armor => _armor;
    public int Damage => _damage;
    public float Speed => _speed;
    public float AttackDelay => _attackDelay;
    public float AttackRange => _attackRange;
    public int Value { get; private set; }

    private void OnValidate()
    {
        Value = CalculateValue(Health, Armor, Damage, Speed, AttackRange, AttackDelay);
    }

    public int RecalculateDamage(int damage) => Mathf.CeilToInt(1.0f * _armor / 100 * damage);

    private float CalculateStatsValue(int health, int armor, int damage, float speed, float range, float delay)
    {
        return health + armor + damage + speed + range;
    }

    private int CalculateValue(int health, int armor, int damage, float speed, float range, float delay)
    {
        float minStatsValue = CalculateStatsValue(MinIntStat, MinIntStat, MinIntStat, MinFloatStat, MinFloatStat, MaxAttackDelay);
        float maxStatsValue = CalculateStatsValue(MaxHealth, MaxArmor, MaxDamage, MaxSpeed, MaxRange, MinFloatStat);
        float statsValueRange = maxStatsValue - minStatsValue;
        float statsValue = CalculateStatsValue(health, armor, damage, speed, range, delay);
        return Mathf.RoundToInt(ValueRange / statsValueRange * (statsValue - minStatsValue) + MinValue);
    }
}