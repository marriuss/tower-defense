using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour, ITargetable
{
    public Vector2 Position => throw new System.NotImplementedException();

    public int Health => throw new System.NotImplementedException();

    public event UnityAction<ITargetable> Died;

    public void TakeHit(Unit attacker)
    {
        throw new System.NotImplementedException();
    }
}
