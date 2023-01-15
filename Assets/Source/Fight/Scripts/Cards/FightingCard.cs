using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCard
{
    private Card _card;

    public Unit Unit => _card.CardInfo.Unit;
    public int ManaCost => _card.CardInfo.Mana;

    public FightingCard(Card card)
    {
        _card = card;
    }
}
