using UnityEngine;

public class LevelsInitializer : MonoBehaviour
{
    [SerializeField] private LevelsPool _levelsPool;
    [SerializeField] private FightSceneLoader _fightSceneLoader;
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _points;
    [SerializeField] private LevelEntry _levelEntry;

    private LevelInfo _currentLevelInfo;

    private void OnEnable()
    {
        _levelEntry.Clicked += OnLevelEntryClicked;
    }

    private void OnDisable()
    {
        _levelEntry.Clicked -= OnLevelEntryClicked;
    }

    private void Start()
    {
        _currentLevelInfo = _levelsPool.LastLevel;

        if (_currentLevelInfo == null)
        {
            Debug.LogError("Can't get current level from pool");
            return;
        }

        _levelEntry.transform.position = _points[_levelsPool.LastLevelOrderIndex].position;
    }

    private void OnLevelEntryClicked(LevelEntry levelEntry)
    {
        var castle = _player.Castle;
        var castleFightStats = new CastleFightStats(
            castle.Health, castle.AdditionalTowersAmount, castle.TowerHealthFraction);
        var fightInfo = new FightInfo(_player.Deck, _currentLevelInfo, castleFightStats);
        _fightSceneLoader.LoadFightScene(fightInfo);
    }
}
