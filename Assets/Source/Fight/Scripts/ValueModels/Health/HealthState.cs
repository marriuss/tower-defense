using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthState
{
    Health _health;

    public int Value => (int)_health?.Value;
    public int MaxValue => (int)_health?.MaxValue;
    public bool IsDead => Value == 0;

    public HealthState(Health health)
    {
        _health = health;
    }
}
