using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private Unit _unit;
    [SerializeField] private Rarity _rarity;
    [SerializeField] private int _mana;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public int Id => _id;
    public Unit Unit => _unit;
    public Rarity Rarity => _rarity;
    public int Mana => _mana;
    public string Name => _name;
    public Sprite Icon => _icon;
}

public enum Rarity
{
    REGULAR,
    RARE,
    LEGEND
}
