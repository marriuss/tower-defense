using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSpawner : UnitSpawner
{
    public void SpawnUnit(FightingCard card)
    {
        Spawn(card.Unit);
    }
}
