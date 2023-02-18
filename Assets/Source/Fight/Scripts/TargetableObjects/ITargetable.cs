using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ITargetable
{
    public Vector2 Position { get; }
    public HealthState HealthState { get; }
    public event Action<ITargetable> Died;
    public void TakeHit(Unit attacker);
}
