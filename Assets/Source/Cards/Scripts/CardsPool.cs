using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName ="CardsPool", menuName ="CardsPool", order =51)]
public class CardsPool : ScriptableObject
{
    [SerializeField] private List<CardInfo> _cardInfos;
    [SerializeField] private List<Card> _cards = new List<Card>();

    public IReadOnlyList<Card> Cards => _cards;
    public IReadOnlyList<Card> UnlockedCards => _cards.Where(card => card.IsUnlocked).ToList();

    private void Awake()
    {
        foreach (CardInfo cardInfo in _cardInfos)
            _cards.Add(new Card(cardInfo));
    }

    public Card FindCardById(int id)
    {
        return _cards.Find(card => card.CardInfo.Id == id);
    }
}
