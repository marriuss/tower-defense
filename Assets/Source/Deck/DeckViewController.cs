using System.Collections.Generic;
using UnityEngine;

public class DeckViewController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CardsPool _cardsPool;
    [SerializeField] private CardView _cardViewPrefab;
    [SerializeField] private RectTransform _cardsContainer;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private List<CardSlot> _deckSlots;

    private Deck _deck;
    private List<CardView> _cardViews = new List<CardView>();

    private void OnEnable()
    {
        foreach (var slot in _deckSlots)
        {
            slot.CardPlaced += OnCardPlaced;
            slot.Freed += OnSlotFreed;
        }

        for (int i = 0; i < _cardViews.Count; i++)
        {
            _cardViews[i].NeedCheckForReturn += OnCardNeedCheckForReturn;
        }
    }

    private void OnDisable()
    {
        foreach (var slot in _deckSlots)
        {
            slot.CardPlaced -= OnCardPlaced;
            slot.Freed -= OnSlotFreed;
        }

        for (int i = 0; i < _cardViews.Count; i++)
        {
            _cardViews[i].NeedCheckForReturn -= OnCardNeedCheckForReturn;
        }
    }

    private void Start()
    {
        _deck = _player.Deck;
        UpdateCards(_cardsPool, _deck);
    }

    private void UpdateCards(CardsPool cardsPool, Deck deck)
    {
        for (int i = 0; i < _cardViews.Count; i++)
        {
            _cardViews[i].NeedCheckForReturn -= OnCardNeedCheckForReturn;
            Destroy(_cardViews[i].gameObject);
        }

        _cardViews.Clear();
        PlaceDeckCards(deck);
        PlaceAvailableCards(cardsPool, deck);
    }

    private void PlaceDeckCards(Deck deck)
    {
        for (int i = 0; i < deck.Cards.Count; i++)
        {
            if (deck.Cards[i] == null)
            {
                continue;
            }

            CardView cardView = CreateCardView(deck.Cards[i], _canvas.transform);
            cardView.NeedCheckForReturn += OnCardNeedCheckForReturn;
            _cardViews.Add(cardView);
            _deckSlots[i].PlaceCard(cardView);
        }
    }

    private void PlaceAvailableCards(CardsPool cardsPool, Deck deck)
    {
        // TODO: filter available cards
        for (int i = 0; i < cardsPool.Cards.Count; i++)
        {
            if (deck.Cards.Contains(cardsPool.Cards[i])) // Except cards in deck to avoid duplication
            {
                continue;
            }

            CardView cardView = CreateCardView(cardsPool.Cards[i], _cardsContainer);
            cardView.NeedCheckForReturn += OnCardNeedCheckForReturn;
            _cardViews.Add(cardView);
        }

        _cardsContainer.anchoredPosition = new Vector2(_cardsContainer.anchoredPosition.x, -_cardsContainer.rect.height);
    }

    private void OnCardPlaced(CardSlot slot, CardView cardView)
    {
        _deck.PlaceCard(cardView.Card, _deckSlots.IndexOf(slot));
        UpdateCards(_cardsPool, _deck);
    }

    private void OnCardNeedCheckForReturn(CardView cardView)
    {
        int cardIndex = _deck.Cards.IndexOf(cardView.Card);
        
        if (cardIndex >= 0)
        {
            _deck.PlaceCard(null, cardIndex);
        }

        UpdateCards(_cardsPool, _deck);
    }

    private void OnSlotFreed(CardSlot slot, CardView cardView)
    {
        int cardIndex = _deck.Cards.IndexOf(cardView.Card);
        _deck.PlaceCard(null, cardIndex);
    }

    private CardView CreateCardView(Card card, Transform parent = null)
    {
        CardView cardView = Instantiate(_cardViewPrefab, parent);
        cardView.Init(card, _canvas);
        return cardView;
    }
}
