using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Wave
{
    [SerializeField] private WaveUnit[] _waveUnits;

    public WaveUnit GetWaveUnit(int index) => _waveUnits[index];
    public List<WaveUnit> Units => new(_waveUnits);
}

[Serializable]
public struct WaveUnit
{
    [SerializeField] private int _unitsCount;
    [SerializeField] private Unit _unitPrefab;

    public int UnitsCount => _unitsCount;
    public Unit UnitPrefab => _unitPrefab;
}
