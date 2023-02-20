using UnityEngine;

public class FightingCard
{
    private CardInfo _cardInfo;

    public Sprite Icon => _cardInfo.Icon;
    public Unit Unit => _cardInfo.Unit;
    public int ManaCost => _cardInfo.Mana;
    public Rarity Rarity => _cardInfo.Rarity;

    public FightingCard(Card card)
    {
        _cardInfo = card.CardInfo;
    }
}
