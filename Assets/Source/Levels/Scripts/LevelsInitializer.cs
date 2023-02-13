using UnityEngine;

public class LevelsInitializer : MonoBehaviour
{
    public const string ForestZoneName = "Forest";
    public const string DesertZoneNmae = "Desert";
    public const string JungleZoneName = "Jungle";
    public const string WinterZoneName = "Winter";

    [SerializeField] private LevelsPool _levelsPool;
    [SerializeField] private FightSceneLoader _fightSceneLoader;
    [SerializeField] private Player _player;
    [SerializeField] private LevelEntry _forestLevelEntry;
    // TODO: add entries for each zone

    private LevelInfo _currentLevelInfo;

    private void OnEnable()
    {
        _forestLevelEntry.Clicked += OnLevelEntryClicked;
    }

    private void OnDisable()
    {
        _forestLevelEntry.Clicked -= OnLevelEntryClicked;
    }

    private void Start()
    {
        DisableAllEntries();
        _currentLevelInfo = _levelsPool.LastLevel;

        if (_currentLevelInfo == null)
        {
            Debug.LogError("Can't get current level from pool");
            return;
        }

        switch (_currentLevelInfo.Zone.Name)
        {
            case ForestZoneName:
                _forestLevelEntry.gameObject.SetActive(true);
                break;
            default:
                Debug.LogError("Can't find entry for level by zone name");
                break;
        }
    }

    private void DisableAllEntries()
    {
        _forestLevelEntry.gameObject.SetActive(false);
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
