using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckView : MonoBehaviour
{
    [SerializeField] private FightCardView _cardViewPrefab;
    [SerializeField] private CardStack _cardStack;
    [SerializeField] private DeckPanelController _deckController;

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

        RenderTopStackCards();
    }

    private void OnEnable()
    {
        foreach(FightCardView fightCardView in _cardViews)
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
        yield return _cardStack.StackGenerated;

        FightingCard card;

        for (int i = 0; i < TopCards; i++)
        {
            card = _cardStack.GetTopCard();
            _cardViews[i].Render(card);
        }
    }

    private void OnCardClicked(FightCardView cardView)
    {
        _deckController.UseCard(cardView.Card);
    }
}
