using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="Player", menuName ="Player", order =51)]
public class Player : ScriptableObject
{
    [HideInInspector, SerializeReference] private Deck _deck = new Deck();
    [HideInInspector, SerializeReference] private Castle _castle = new Castle();
    [HideInInspector, SerializeReference] private Balance _balance = new Balance();

    public Deck Deck => _deck;
    public Castle Castle => _castle;
    public Balance Balance => _balance;

    public void Initialize(List<DeckItem> deckCards, int castleLevel, int money)
    {
        _deck.Initialize(deckCards);
        _castle.Initialize(castleLevel);
        _balance.Initialize(money);
    }
}
