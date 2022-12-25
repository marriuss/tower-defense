using System;
using UnityEngine;

[Serializable]
public struct Wave
{
    [SerializeField] private WaveUnit[] _waveUnits;

    public WaveUnit GetWaveUnit(int index) => _waveUnits[index];
}

[Serializable]
public struct WaveUnit
{
    [SerializeField] private int _unitsCount;
    [SerializeField] private Unit _unitPrefab;

    public int UnitsCount => _unitsCount;
    public Unit UnitPrefab => _unitPrefab;
}
