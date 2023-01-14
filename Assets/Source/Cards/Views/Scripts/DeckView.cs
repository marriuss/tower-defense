using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckView : MonoBehaviour
{
    [SerializeField] private FightCardView _cardViewPrefab;
    [SerializeField] private CardStack _cardStack;

    private const int TopCards = 5;

    private List<FightCardView> _cardViews = new();

    private void Awake()
    {
        FightCardView cardView;

        for (int i = 0; i < TopCards; i++)
        {
            cardView = Instantiate(_cardViewPrefab, transform);
            _cardViews.Add(cardView);
        }
    }

    private void OnEnable()
    {
        _cardStack.StackGenerated += OnCardStackGenerated;
    } 

    private void OnDisable()
    {
        _cardStack.StackGenerated -= OnCardStackGenerated;
    }

    private void OnCardStackGenerated()
    {
        FightingCard card;

        for (int i = 0; i < TopCards; i++)
        {
            card = _cardStack.GetTopCard();
            _cardViews[i].Render(card);
        }
    }
}
