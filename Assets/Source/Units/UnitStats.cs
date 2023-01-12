using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New UnitStats", menuName ="SO/UnitStats", order =51)]
public class UnitStats : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _attackRange;

    public int Health => _health;
    public int Damage => _damage;
    public float Speed => _speed;
    public float AttackDelay => _attackDelay;
    public float AttackRange => _attackRange;
}
