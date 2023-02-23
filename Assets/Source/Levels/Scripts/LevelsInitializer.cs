using UnityEngine;

public class LevelsInitializer : MonoBehaviour
{
    [SerializeField] private LevelsPool _levelsPool;
    [SerializeField] private FightSceneLoader _fightSceneLoader;
    [SerializeField] private Player _player;
    [SerializeField] private LevelEntry[] _levelEntries;

    private LevelInfo _currentLevelInfo;

    private void OnEnable()
    {
        for (int i = 0; i < _levelEntries.Length; i++)
        {
            _levelEntries[i].Clicked += OnLevelEntryClicked;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _levelEntries.Length; i++)
        {
            _levelEntries[i].Clicked -= OnLevelEntryClicked;
        }
    }

    private void Start()
    {
        _currentLevelInfo = _levelsPool.LastLevel;

        if (_currentLevelInfo == null)
        {
            Debug.LogError("Can't get current level from pool");
            return;
        }

        for (int i = 0; i < _levelEntries.Length; i++)
        {
            LevelState levelState = LevelState.Inaccessible;

            if (i < _levelsPool.LastLevelOrderIndex)
            {
                levelState = LevelState.Completed;
            }
            else if (i == _levelsPool.LastLevelOrderIndex)
            {
                levelState = LevelState.Current;
            }

            _levelEntries[i].Init(levelState);
        }
    }

    private void OnLevelEntryClicked(LevelEntry levelEntry)
    {
        for (int i = 0; i < _levelEntries.Length; i++)
        {
            _levelEntries[i].Disable();
        }

        var castle = _player.Castle;
        var castleFightStats = new CastleFightStats(
            castle.Health, castle.AdditionalTowersAmount, castle.TowerHealthFraction);
        var fightInfo = new FightInfo(_player.Deck, _currentLevelInfo, castleFightStats);
        _fightSceneLoader.LoadFightScene(fightInfo);
    }
}
