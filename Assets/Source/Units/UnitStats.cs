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

    [SerializeField, Range(1, MaxHealth)] private int _health;
    [SerializeField, Range(1, MaxArmor)] private int _armor;
    [SerializeField, Range(MinIntStat, MaxDamage)] private int _damage;
    [SerializeField, Range(MinFloatStat, MaxSpeed)] private float _speed;
    [SerializeField, Range(MinFloatStat, MaxAttackDelay)] private float _attackDelay;
    [SerializeField, Range(MinFloatStat, MaxRange)] private float _attackRange;
    
    [HideInInspector, SerializeField] private float _levelBuff = 1.0f;

    private const int MinIntStat = 1;
    private const int MaxArmor = 30;
    private const int MaxHealth = 50;
    private const int MaxDamage = 40;
    private const float MinFloatStat = 0.1f;
    private const float MaxSpeed = 3;
    private const float MaxAttackDelay = 2f;
    private const float MaxRange = 10f;

    public string Name { get; private set; }
    public int Health => Mathf.RoundToInt(_health * _levelBuff);
    public int Armor => Mathf.RoundToInt(_armor * _levelBuff);
    public int Damage => Mathf.RoundToInt(_damage * _levelBuff);
    public float Speed => _speed * _levelBuff;
    public float AttackDelay => _attackDelay / _levelBuff;
    public float AttackRange => _attackRange * _levelBuff;
    public int Value { get; private set; }

    private void Awake()
    {
        Value = CalculateValue(_health, _armor, _damage, _speed, _attackRange, _attackDelay);
        Name = name;
    }

    public void ApplyLevelBuff(int level)
    {
        _levelBuff = 1 + (level - 1) * 0.1f;
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