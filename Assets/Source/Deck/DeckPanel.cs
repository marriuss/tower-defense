using System.Collections.Generic;
using UnityEngine;

public class DeckPanel : Panel
{
    [SerializeField] private CardViewController _cardViewControllerPrefab;
    [SerializeField] private CardsPool _cardsPool;
    [SerializeField] private RectTransform _cardsContainer;
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        _cardsPool.InitializeCardsPool(new List<CardProgress>() 
        { 
            new CardProgress(0, 1, 2)
        });

        for (int i = 0; i < _cardsPool.Cards.Count; i++)
        {
            CardViewController cardViewController = Instantiate(_cardViewControllerPrefab, _cardsContainer);
            cardViewController.Init(_cardsPool.Cards[i], _canvas);
        }

        _cardsContainer.anchoredPosition = new Vector2(_cardsContainer.anchoredPosition.x, -_cardsContainer.rect.height);
    }
}
