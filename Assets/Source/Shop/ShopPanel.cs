using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : Panel
{
    [SerializeField] private CardsPool _cardsPool;
    [SerializeField] private Player _player;
    [SerializeField] private ShopCardView _cardViewPrefab;
    [SerializeField] private Transform _container;

    private List<ShopCardView> _cardViews;

    private void OnDestroy()
    {
        for (int i = 0; i < _cardViews?.Count; i++)
        {
            _cardViews[i].CardPurchased -= OnCardPurchased;
        }
    }

    private void Start()
    {
        _cardViews = new List<ShopCardView>();

        for (int i = 0; i < _cardsPool.Cards.Count; i++)
        {
            ShopCardView cardView = Instantiate(_cardViewPrefab, _container);
            _cardViews.Add(cardView);
            cardView.Init(_cardsPool.Cards[i], _player.Balance);
            cardView.CardPurchased += OnCardPurchased;
        }
    }

    private void OnCardPurchased(Card card)
    {
        card.Unlock();

        for (int i = 0; i < _cardViews.Count; i++)
        {
            _cardViews[i].Init(_cardsPool.Cards[i], _player.Balance);
        }
    }
}
