using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSpawner : UnitSpawner
{
    [SerializeField] private Unit _test;

    private void Start()
    {
        Spawn(_test);
    }

    public void SpawnUnit(FightingCard card)
    {
        Spawn(card.Unit);
    }
}
