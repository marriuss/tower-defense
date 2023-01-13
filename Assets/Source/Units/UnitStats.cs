using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New UnitStats", menuName ="SO/UnitStats", order =51)]
public class UnitStats : ScriptableObject
{
    private const int MaxArmor = 50;

    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField, Range(0, MaxArmor)] private int _armor;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _attackRange;

    public string Name => _name;
    public int Health => _health;
    public int Armor => _armor;
    public int Damage => _damage;
    public float Speed => _speed;
    public float AttackDelay => _attackDelay;
    public float AttackRange => _attackRange;
    
    public int RecalculateDamage(int damage) => Mathf.CeilToInt(1.0f * _armor / 100 * damage);
}
