using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="Player", menuName ="Player", order =51)]
public class Player : ScriptableObject
{
    [SerializeField] private Deck _deck = new Deck();
    [SerializeField] private Castle _castle = new Castle();
    [SerializeField] private Balance _balance = new Balance();

    public Deck Deck => _deck;
    public Castle Castle => _castle;
    public Balance Balance => _balance;
    
    public event UnityAction DataChanged;

    private void OnEnable()
    {
        _deck.CardsChanged += OnDataChanged;
        _castle.StatsChanged += OnDataChanged;
        _balance.MoneyCountChanged += (int money) => OnDataChanged();
    }

    private void OnDisable()
    {
        _deck.CardsChanged -= OnDataChanged;
        _castle.StatsChanged -= OnDataChanged;
        _balance.MoneyCountChanged -= (int money) => OnDataChanged();
    }

    public void Initialize(Deck deck, Balance balance, Castle castle)
    {
        _deck = deck;
        _balance = balance;
        _castle = castle;
    }

    private void OnDataChanged()
    {
        DataChanged?.Invoke();
    }
}
