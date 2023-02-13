using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Events;

public class CardStack : MonoBehaviour
{
    private Stack<FightingCard> _cards = new Stack<FightingCard>();

    public bool StackGenerated { get; private set; }
    public int UniqueCardsAmount { get; private set; }
    public int StackCapacity { get; private set; }
    public int StackCount => _cards.Count;

    private void Start()
    {
        StackGenerated = false;
    }

    public void GenerateStack(HashSet<Card> cardSet, int cardAmount)
    {
        UniqueCardsAmount = cardSet.Count;
        StackCapacity = cardAmount;

        if (UniqueCardsAmount == 0)
            return;

        if (StackCapacity == 0)
            return;

        if (StackCapacity < 0)
            throw new NegativeArgumentException();

        List<FightingCard> cardsList = new List<FightingCard>();

        for (int i = 0; i < cardAmount; i++)
        {
            foreach (Card card in cardSet)
                cardsList.Add(new FightingCard(card));
        }

        cardsList = Utils.Shuffle(cardsList).ToList();
        _cards = new Stack<FightingCard>(cardsList);
        StackGenerated = true;
    }

    public FightingCard GetTopCard()
    {
        if (_cards.Count == 0)
            return null;

        return _cards.Pop();
    }
}
