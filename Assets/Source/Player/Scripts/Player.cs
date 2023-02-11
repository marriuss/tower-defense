using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="Player", menuName ="Player", order =51)]
public class Player : ScriptableObject
{
    [SerializeReference] private Deck _deck = new Deck();
    [SerializeReference] private Castle _castle = new Castle();
    [SerializeReference] private Balance _balance = new Balance();

    public Deck Deck => _deck;
    public Castle Castle => _castle;
    public Balance Balance => _balance;

    public void Initialize(Deck deck, Balance balance, Castle castle)
    {
        _deck = deck;
        _balance = balance;
        _castle = castle;
    }
}
