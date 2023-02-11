using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class Deck
{
    private List<Card> _cards;

    public const int Capacity = 8;

    public List<Card> Cards => new List<Card>(_cards);

    public event UnityAction CardsChanged;

    public Deck()
    {
        InitializeCardsList();
    }

    public Deck(List<DeckItem> deckItems)
    {
        InitializeCardsList();

        foreach (DeckItem item in deckItems)
            PlaceCardToIndex(item.Card, item.Index);
    }

    public Card PlaceCard(Card card, int index)
    {
        Card replacedCard = PlaceCardToIndex(card, index);

        if (replacedCard != card)
            CardsChanged?.Invoke();

        return replacedCard;
    }

    public void ApplyExperiencePoints(int cardExperiencePoints)
    {
        foreach (Card card in _cards)
        {
            if (card != null)
                card.AddExperiencePoints(cardExperiencePoints);
        }

        CardsChanged?.Invoke();
    }

    public int? GetCardIndex(Card card)
    {
        int? index = _cards.IndexOf(card);

        if (index == -1)
            index = null;

        return index;
    }

    private void InitializeCardsList()
    {
        _cards = new List<Card>(Capacity);

        for (int i = 0; i < Capacity; i++)
            _cards.Add(null);
    }

    private Card PlaceCardToIndex(Card card, int index)
    {
        if (0 > index || index >= Capacity)
            throw new ArgumentOutOfRangeException();

        Card replacedCard = _cards[index];
        _cards[index] = card;

        return replacedCard;
    }
}

public struct DeckItem
{
    public Card Card { get; private set; }
    public int Index { get; private set; }

    public DeckItem(Card card, int index)
    {
        Card = card;
        Index = index;
    }
}