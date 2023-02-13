using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCard
{
    private Card _card;

    public Sprite Icon => _card.CardInfo.Icon;
    public Unit Unit => _card.CardInfo.Unit;
    public int ManaCost => _card.CardInfo.Mana;
    public Rarity Rarity => _card.CardInfo.Rarity;
    public LeanPhrase Name => _card.CardInfo.Name;

    public FightingCard(Card card)
    {
        _card = card;
    }
}
