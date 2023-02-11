using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardInfo", menuName = "SO/CardInfo", order = 51)]
public class CardInfo : ScriptableObject
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Rarity _rarity;
    [SerializeField] private int _mana;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public int Id { get; private set; }
    public Unit Unit => _unit;
    public Rarity Rarity => _rarity;
    public int Mana => _mana;
    public string Name => _name;
    public Sprite Icon => _icon;

    public void SetId(int id)
    {
        Id = id;
    }
}

public enum Rarity
{
    REGULAR,
    RARE,
    LEGEND
}
