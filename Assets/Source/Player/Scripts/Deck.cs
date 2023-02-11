using System;
using System.Collections.Generic;

public class Deck
{
    private const int Capacity = 8;

    private List<Card> _cards;
    
    public List<Card> Cards => new List<Card>(_cards);

    public Deck()
    {
        _cards = new List<Card>(Capacity);

        for (int i = 0; i < Capacity; i++)
            _cards.Add(null);
    }

    public Card PlaceCard(Card card, int index)
    {
        if (0 > index || index >= Capacity)
            throw new ArgumentOutOfRangeException();

        Card replacedCard = _cards[index];
        _cards[index] = card;
        return replacedCard;
    }

    public int? GetCardIndex(Card card)
    {
        int? index = _cards.IndexOf(card);

        if (index == -1)
            index = null;

        return index;
    }
}
