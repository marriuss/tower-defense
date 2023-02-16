using System;
using System.Collections.Generic;
using UnityEngine.Events;

[Serializable]
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

        Card card;
        foreach (DeckItem item in deckItems)
        {
            card = item.Card;
            card.Unlock();
            PlaceCardToIndex(item.Card, item.Index);
        }
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
        for (int i = 0; i < Capacity; i++)
        {
            if (IsPlaceEmpty(i) == false)
                _cards[i].AddExperiencePoints(cardExperiencePoints);
        }

        CardsChanged?.Invoke();
    }

    public int GetCardIndex(Card card) => _cards.IndexOf(card);
    public bool HasCard(Card card) => GetCardIndex(card) >= 0;

    public bool CheckIsInDeck(Card card)
    {
        if (CheckIsCardNull(card) == false)
            return _cards.Contains(card);

        return false;
    }

    public bool IsPlaceEmpty(int index)
    {
        Card card = _cards[index];
        return CheckIsCardNull(card);
    }

    private void InitializeCardsList()
    {
        _cards = new List<Card>();

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

    private bool CheckIsCardNull(Card card) => card == null || card.CardInfo == null;
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