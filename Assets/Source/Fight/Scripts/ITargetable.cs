using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable
{
    public Vector2 Position { get; }
    public int Health { get; }
}