using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckViewController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CardsPool _cardsPool;
    [SerializeField] private CardView _cardViewPrefab;
    [SerializeField] private RectTransform _cardsContainer;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CardSlot _cardSlotPrefab;
    [SerializeField] private Transform _cardSlotsContainer;

    private Deck _deck;
    private List<CardView> _cardViews = new List<CardView>();
    private List<CardSlot> _deckSlots;

    private void Awake()
    {
        CreateSlots(Deck.Capacity);
    }

    private void OnEnable()
    {
        for (int i = 0; i < _deckSlots.Count; i++)
        {
            _deckSlots[i].CardPlaced += OnCardPlaced;
            _deckSlots[i].Freed += OnSlotFreed;
        }

        for (int i = 0; i < _cardViews.Count; i++)
        {
            _cardViews[i].NeedCheckForReturn += OnCardNeedCheckForReturn;
        }
    }

    private void OnDisable()
    {
        for(int i = 0; i < _deckSlots.Count; i++)
        {
            _deckSlots[i].CardPlaced -= OnCardPlaced;
            _deckSlots[i].Freed -= OnSlotFreed;
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

    private void CreateSlots(int slotsCount)
    {
        _deckSlots = new List<CardSlot>();

        for (int i = 0; i < slotsCount; i++)
        {
            CardSlot slot = Instantiate(_cardSlotPrefab, _cardSlotsContainer);
            _deckSlots.Add(slot);
        }
    }

    private void UpdateCards(CardsPool cardsPool, Deck deck)
    {
        for (int i = 0; i < _cardViews.Count; i++)
        {
            _cardViews[i].NeedCheckForReturn -= OnCardNeedCheckForReturn;
            Destroy(_cardViews[i].gameObject);
        }

        _cardViews.Clear();
        PlaceAvailableCards(cardsPool, deck);
        PlaceDeckCards(deck);
    }

    private void PlaceDeckCards(Deck deck)
    {
        List<Card> cards = deck.Cards;

        for (int i = 0; i < cards.Count; i++)
        {
            if (deck.IsPlaceEmpty(i))
            {
                continue;
            }

            CardView cardView = CreateCardView(cards[i], _canvas.transform);
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
            if (deck.Cards.FirstOrDefault(c => c.CardInfo == cardsPool.Cards[i].CardInfo) != null) // Except cards in deck to avoid duplication
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
