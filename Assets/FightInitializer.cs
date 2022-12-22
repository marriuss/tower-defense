using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FightInitializer : MonoBehaviour
{
    [SerializeField] private CardStack _cardStack;

    private void InitializeCardStack(Deck deck, int cardStackCapacity)
    {
        HashSet<Card> cardSet = deck.Cards.Where(card => card != null).ToHashSet();
        _cardStack.GenerateStack(cardSet, cardStackCapacity);
    }
}
