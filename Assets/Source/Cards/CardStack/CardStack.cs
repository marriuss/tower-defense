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

    public void GenerateStack(HashSet<Card> cardSet, int amount)
    {
        UniqueCardsAmount = cardSet.Count;
        StackCapacity = amount;

        if (UniqueCardsAmount == 0)
            return;

        if (StackCapacity == 0)
            return;

        if (StackCapacity < 0)
            throw new NegativeArgumentException();


        cardSet = CardSorter.SortCardsByRarity(cardSet, descending: false).ToHashSet();

        int stackCount = 0;
        bool isStackFull = false;

        while (isStackFull == false)
        {
            foreach (Card card in cardSet)
            {
                if (stackCount == amount)
                    break;

                AddCard(card);
                stackCount++;
            }

            isStackFull = stackCount == amount;
        }

        StackGenerated = true;
    }

    public FightingCard GetTopCard()
    {
        if (_cards.Count == 0)
            return null;

        return _cards.Pop();
    }

    private void AddCard(Card card)
    {
        _cards.Push(new FightingCard(card));
    }
}
