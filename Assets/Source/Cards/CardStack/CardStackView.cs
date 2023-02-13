using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardStackView : MonoBehaviour
{
    [SerializeField] private FightCardView _cardViewPrefab;
    [SerializeField] private CardStack _cardStack;
    [SerializeField] private CardStackController _controller;
    [SerializeField] private TopCardView _topCardViewPrefab;

    private const int TopCards = 5;

    private List<FightCardView> _cardViews = new();
    private FightingCard _topCard;
    private TopCardView _topCardView;

    private void Awake()
    {
        FightCardView cardView;

        for (int i = 0; i < TopCards; i++)
        {
            cardView = Instantiate(_cardViewPrefab, transform);
            _cardViews.Add(cardView);
        }

        _topCardView = Instantiate(_topCardViewPrefab, transform);
        RenderTopStackCards();
    }

    private void OnEnable()
    {
        foreach (FightCardView fightCardView in _cardViews)
            fightCardView.Clicked += OnCardClicked;
    }

    private void OnDisable()
    {
        foreach (FightCardView fightCardView in _cardViews)
            fightCardView.Clicked -= OnCardClicked;
    }

    private void RenderTopStackCards()
    {
        StartCoroutine(RenderWhenStackGenerated());
    }

    private IEnumerator RenderWhenStackGenerated()
    {
        if (_cardStack.StackGenerated == false)
            yield return null;

        for (int i = 0; i < TopCards; i++)
            AssignCard(_cardViews[i], _cardStack.GetTopCard());

        AssignTopCard();
    }

    private void OnCardClicked(FightCardView cardView)
    {
        _controller.UseCard(cardView.Card);
        cardView.Render(_topCard);
        AssignTopCard();
    }

    private void AssignCard(FightCardView cardView, FightingCard card)
    {
        if (card != null)
        {
            cardView.Render(card);
        }
        else
        {
            cardView.gameObject.SetActive(false);
        }
    }

    private void AssignTopCard()
    {
        _topCard = _cardStack.GetTopCard();

        if (_topCard != null)
        {
            _topCardView.Render(_cardStack.StackCount + 1, _cardStack.StackCapacity, _topCard.Rarity);
        }
        else
        {
            _topCardView.gameObject.SetActive(false);
        }
    }
}
