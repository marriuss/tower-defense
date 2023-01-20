using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats
{
    public int Health { get; private set; }

    public TowerStats(int health)
    {
        Health = health;
    }
}
