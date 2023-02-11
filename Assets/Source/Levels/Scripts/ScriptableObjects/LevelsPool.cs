using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="LevelsPool", menuName ="LevelsPool", order =51)]
public class LevelsPool : ScriptableObject
{
    [SerializeField] private List<LevelInfo> _levels;
    [SerializeField, Min(0)] private int _lastLevelId;

    public int LastLevelId => _lastLevelId;
    public IReadOnlyList<LevelInfo> Levels => _levels;

    public event UnityAction LastLevelChanged;

    public void Initialize(int id)
    {
        ChangeLastLevelId(id);
    }

    public void SetLastLevelId(int id)
    {
        ChangeLastLevelId(id);
        LastLevelChanged?.Invoke();
    }

    private void ChangeLastLevelId(int id)
    {
        if (id == _lastLevelId)
            return;

        if (id < _lastLevelId)
            throw new ArgumentException("New last level Id cannot be lesser then current.");

        _lastLevelId = id;
    }
}
