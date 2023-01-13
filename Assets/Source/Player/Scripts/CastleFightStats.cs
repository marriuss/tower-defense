using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleFightStats
{
    public int Health { get; private set; }
    public int TowersAmount { get; private set; }

    public CastleFightStats(int health, int towersAmount)
    {
        Health = health;
        TowersAmount = towersAmount; 
    }
}
