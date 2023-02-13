using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStackController : MonoBehaviour
{
    [SerializeField] private ManaController _manaController;
    [SerializeField] private PlayerUnitSpawner _spawner;

    public void UseCard(FightingCard card)
    {
        int mana = card.ManaCost;

        if (_manaController.CanSpendMana(mana))
        {
            _manaController.SpendMana(mana);
            _spawner.SpawnUnit(card);
        }
    }
}
