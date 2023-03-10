using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ShopPanel : Panel
{
    public event UnityAction PurchasePerformed;

    [SerializeField] private CardsPool _cardsPool;
    [SerializeField] private Player _player;
    [SerializeField] private CardPurchase _cardPurchasePrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private CardInfoPanel _cardInfoPanel;
    [SerializeField] private RandomCardPurchase _randomCardPurchase;

    private Dictionary<CardPurchase, Card> _cardPurchases;

    private void Start()
    {
        _cardPurchases = new Dictionary<CardPurchase, Card>();
        Card[] cards = _cardsPool.Cards.Where(c => c.IsUnlocked == false)
            .OrderBy(c => c.CardInfo.Rarity).ToArray();

        for (int i = 0; i < cards.Length; i++)
        {
            Card card = cards[i];
            CreateCardPurchase(card);
        }

        _randomCardPurchase.Init(_cardPurchases.Select(c => c.Key).ToList());
        _cardInfoPanel.ReInit(_cardPurchases.Select(c => c.Key as CardPointerEnterExitDetector).ToList());
    }

    protected override void OnEnabled()
    {
        _player.Balance.MoneyCountChanged += OnMoneyCountChanged;
    }


    protected override void OnDisabled()
    {
        foreach (var cardPurchase in _cardPurchases.Keys)
        {
            cardPurchase.CardPurchased -= OnCardPurchased;
        }

        _player.Balance.MoneyCountChanged -= OnMoneyCountChanged;
    }

    private void CreateCardPurchase(Card card)
    {
        CardPurchase cardPurchase = Instantiate(_cardPurchasePrefab, _container);
        _cardPurchases.Add(cardPurchase, card);
        cardPurchase.Init(card, _player.Balance);
        cardPurchase.CardPurchased += OnCardPurchased;
    }

    private void OnCardPurchased(CardPurchase cardPurchaseCaller)
    {
        UpdateCards();
        _randomCardPurchase.UpdateView();
        PurchasePerformed?.Invoke();
    }

    private void OnMoneyCountChanged(int money)
    {
        UpdateCards();
    }

    private void UpdateCards()
    {
        foreach (var cardPurchase in _cardPurchases.Keys)
        {
            cardPurchase.UpdateView();
        }
    }
}
