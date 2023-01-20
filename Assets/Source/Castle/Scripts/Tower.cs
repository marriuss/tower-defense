using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteFader))]
public class Tower : MonoBehaviour, ITargetable
{
    public Vector2 Position => transform.position;

    private SpriteFader _spiteFader;
    private Health _health;

    public int Health => _health.Value;
    public bool Dead => _health.IsMin;

    public event UnityAction<ITargetable> Died;

    private void Awake()
    {
        _spiteFader = GetComponent<SpriteFader>();
    }

    public void SetStats(TowerStats stats)
    {
        _health = new Health(stats.Health);
    }

    public void TakeHit(Unit attacker)
    {
        int damage = attacker.Stats.Damage;
        _health.DecreaseValue(damage);

        if (Dead)
            Die();
    }

    private void Die()
    {
        Died?.Invoke(this);
        _spiteFader.FadeOut();
    }
}
