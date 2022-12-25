using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    private const int Capacity = 10;

    private List<Card> _cards;

    public List<Card> Cards => new List<Card>(_cards);

    public Deck()
    {
        _cards = new List<Card>(Capacity);
    }
}
