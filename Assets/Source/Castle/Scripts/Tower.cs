using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteFader))]
public class Tower : MonoBehaviour, ITargetable
{
    private SpriteFader _spiteFader;
    private Health _health;

    public Vector2 Position => transform.position;
    public HealthState HealthState { get; private set; }

    public event Action<ITargetable> Died;

    private void Awake()
    {
        _spiteFader = GetComponent<SpriteFader>();
    }

    public void SetStats(TowerStats stats)
    {
        _health = new Health(stats.Health);
        HealthState = new HealthState(_health);
    }

    public void TakeHit(Unit attacker)
    {
        int damage = attacker.Stats.Damage;
        _health.DecreaseValue(damage);

        if (HealthState.IsDead)
            Die();
    }

    private void Die()
    {
        Died?.Invoke(this);
        _spiteFader.FadeOut();
    }
}
