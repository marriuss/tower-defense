using System;
using System.Collections.Generic;
using UnityEngine;
 
[Serializable]
public struct Wave
{
    [SerializeField] private WaveUnit[] _waveUnits;

    private List<Unit> _units;

    public List<Unit> Units
    {
        get
        {
            if (_units.Count == 0)
                GenerateUnitsList();

            return _units;
        }
    }

    private void GenerateUnitsList()
    {
        _units = new();

        foreach (WaveUnit waveUnit in _waveUnits)
        {
            for (int i = 0; i < waveUnit.UnitsCount; i++)
                _units.Add(waveUnit.UnitPrefab);
        }
    }
}


[Serializable]
public struct WaveUnit
{
    [SerializeField] private int _unitsCount;
    [SerializeField] private Unit _unitPrefab;

    public int UnitsCount => _unitsCount;
    public Unit UnitPrefab => _unitPrefab;
}
