using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LevelsPool", menuName = "LevelsPool", order = 51)]
public class LevelsPool : ScriptableObject
{
    [SerializeField] private List<LevelInfo> _levels;
    [HideInInspector, SerializeField] private int _lastLevelId;
    [HideInInspector, SerializeField] private int _maxLevelId;

    private void Awake()
    {
        static int LevelId(LevelInfo level) => level.Id;
        _lastLevelId = _levels.Min(LevelId);
        _maxLevelId = _levels.Max(LevelId);
    }

    public int LastLevelId => _lastLevelId;
    public LevelInfo LastLevel => _levels.FirstOrDefault(l => l.Id == LastLevelId);
    public int LastLevelOrderIndex => _levels.IndexOf(LastLevel);

    public event UnityAction LastLevelChanged;

    public void SetLastLevelId(int id)
    {
        if (id == _lastLevelId)
            return;

        if (id > _maxLevelId)
            return;

        if (id < _lastLevelId)
            throw new ArgumentException("New last level Id cannot be lesser then current.");

        _lastLevelId = id;
        LastLevelChanged?.Invoke();
    }
}
