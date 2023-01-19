using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour, ITargetable
{
    public Vector2 Position => transform.position;

    private Health _health;

    public int Health => _health.Value;
    public bool Dead => _health.IsMin;

    public event UnityAction<ITargetable> Died;

    private void Awake()
    {
        _health = new Health();
    }

    public void TakeHit(Unit attacker)
    {
    }
}
