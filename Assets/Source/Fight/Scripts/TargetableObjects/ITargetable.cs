using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ITargetable
{
    public Vector2 Position { get; }
    public int Health { get; }
    public event UnityAction<ITargetable> Died;
    public void TakeHit(Unit attacker);
}
