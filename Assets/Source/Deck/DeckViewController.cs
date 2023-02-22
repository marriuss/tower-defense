using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckViewController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CardsPool _cardsPool;
    [SerializeField] private DeckCardView _cardViewPrefab;
    [SerializeField] private RectTransform _cardsContainer;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CardSlot _cardSlotPrefab;
    [SerializeField] private Transform _cardSlotsContainer;
    [SerializeField] public CardInfoPanel _cardInfoPanel;
    [SerializeField] private ShopPanel _shopPanel;

    private Deck _deck;
    private List<DeckCardView> _cardViews = new List<DeckCardView>();
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

        _shopPanel.PurchasePerformed += OnPurchasePerformed;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _deckSlots.Count; i++)
        {
            _deckSlots[i].CardPlaced -= OnCardPlaced;
            _deckSlots[i].Freed -= OnSlotFreed;
        }

        for (int i = 0; i < _cardViews.Count; i++)
        {
            _cardViews[i].NeedCheckForReturn -= OnCardNeedCheckForReturn;
        }

        _shopPanel.PurchasePerformed -= OnPurchasePerformed;
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
        _cardInfoPanel.ReInit(_cardViews.Select(c => c as CardPointerEnterExitDetector).ToList());
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

            DeckCardView cardView = CreateCardView(cards[i], _canvas.transform);
            cardView.NeedCheckForReturn += OnCardNeedCheckForReturn;
            _cardViews.Add(cardView);
            _deckSlots[i].PlaceCard(cardView);
        }
    }

    private void PlaceAvailableCards(CardsPool cardsPool, Deck deck)
    {
        Card[] cards = cardsPool.Cards.Where(c => c.IsUnlocked && deck.HasCard(c) == false)
            .OrderBy(c => c.CardInfo.Rarity).ToArray();

        for (int i = 0; i < cards.Length; i++)
        {
            DeckCardView cardView = CreateCardView(cards[i], _cardsContainer);
            cardView.NeedCheckForReturn += OnCardNeedCheckForReturn;
            _cardViews.Add(cardView);
        }

        _cardsContainer.anchoredPosition = new Vector2(_cardsContainer.anchoredPosition.x, -_cardsContainer.rect.height);
    }

    private void OnCardPlaced(CardSlot slot, DeckCardView cardView)
    {
        _deck.PlaceCard(cardView.Card, _deckSlots.IndexOf(slot));
        UpdateCards(_cardsPool, _deck);
    }

    private void OnCardNeedCheckForReturn(DeckCardView cardView)
    {
        if (_deck.HasCard(cardView.Card))
        {
            int cardIndex = _deck.Cards.IndexOf(cardView.Card);
            _deck.PlaceCard(null, cardIndex);
        }

        UpdateCards(_cardsPool, _deck);
    }

    private void OnSlotFreed(CardSlot slot, DeckCardView cardView)
    {
        int cardIndex = _deck.Cards.IndexOf(cardView.Card);
        _deck.PlaceCard(null, cardIndex);
    }

    private DeckCardView CreateCardView(Card card, Transform parent = null)
    {
        DeckCardView cardView = Instantiate(_cardViewPrefab, parent);
        cardView.Init(card, _canvas);
        return cardView;
    }

    private void OnPurchasePerformed()
    {
        UpdateCards(_cardsPool, _deck);
    }
}
