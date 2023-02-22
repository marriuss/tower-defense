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

        _cardInfoPanel.ReInit(_cardPurchases.Select(c => c.Key as CardPointerEnterExitDetector).ToList());
    }

    private void CreateCardPurchase(Card card)
    {
        CardPurchase cardPurchase = Instantiate(_cardPurchasePrefab, _container);
        _cardPurchases.Add(cardPurchase, card);
        cardPurchase.Init(card, _player.Balance);
        cardPurchase.CardPurchased += OnCardPurchased;
    }

    private void OnDisable()
    {
        foreach (var cardPurchase in _cardPurchases.Keys)
        {
            cardPurchase.CardPurchased -= OnCardPurchased;
        }
    }

    private void OnCardPurchased(CardPurchase cardPurchaseCaller)
    {
        foreach (var cardPurchase in _cardPurchases.Keys)
        {
            cardPurchase.UpdateView();
        }

        PurchasePerformed?.Invoke();
    }
}
