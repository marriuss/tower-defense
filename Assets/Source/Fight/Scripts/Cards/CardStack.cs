using System.Collections.Generic;
using UnityEngine;
using System;

public class CardStack : MonoBehaviour
{
    private Stack<FightingCard> _cards = new Stack<FightingCard>();

    public void GenerateStack(HashSet<Card> cardSet, int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount of cards in stack cannot be non-positive.");

        cardSet = CardSorter.SortCardsByRarity(cardSet, descending: false);

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
