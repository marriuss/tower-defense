using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : Panel
{
    [SerializeField] private CardsPool _cardsPool;
    [SerializeField] private Player _player;
    [SerializeField] private CardPurchase _cardPurchasePrefab;
    [SerializeField] private Transform _container;

    private Dictionary<CardPurchase, Card> _cardPurchases;

    private void Start()
    {
        _cardPurchases = new Dictionary<CardPurchase, Card>();

        for (int i = 0; i < _cardsPool.Cards.Count; i++)
        {
            Card card = _cardsPool.Cards[i];
            CreateCardPurchase(card);
        }
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
    }
}
