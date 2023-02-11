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

    public Deck(List<Card> cards)
    {
        _cards = cards;
    }

    public void SetCards(List<Card> cards)
    {
        _cards = cards;
    }

    public Card PlaceCard(Card card, int index)
    {
        if (0 > index || index >= Capacity)
            throw new ArgumentOutOfRangeException();

        Card replacedCard = _cards[index];
        _cards[index] = card;
        return replacedCard;
    }
}
