using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsPool : MonoBehaviour
{
    [SerializeField] private List<CardInfo> _cardInfos;

    private List<Card> _cards;

    public IReadOnlyList<Card> Cards => _cards;

    private void Awake()
    {
        _cards = new List<Card>();
    }

    public void InitializeCardsPool(List<CardProgress> cardProgress)
    {
        CardProgress progress;
        Card card;

        foreach (CardInfo cardInfo in _cardInfos)
        {
            progress = cardProgress.Find(progress => progress.Id == cardInfo.Id);
            card = progress != null ? new Card(cardInfo, progress.Level, progress.ExperiencePoints) : new Card(cardInfo);
            _cards.Add(card);
        }
    }
}
