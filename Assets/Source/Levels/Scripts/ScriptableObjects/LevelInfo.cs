using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Level Info", menuName = "SO/Level Info", order = 51)]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private uint _identifier;
    [SerializeField] private Zone _zone;
    [SerializeField] private Wave[] _waves;
    [SerializeField] private int _cardStackCapacity;
    [SerializeField] private int _moneyReward;

    public int Id => (int)_identifier;
    public Zone Zone => _zone;
    public Wave GetWave(int index) => _waves[index];
    public int CardStackCapacity => _cardStackCapacity;
    public int MoneyReward => _moneyReward;
    public List<Wave> Waves => new(_waves);
}
