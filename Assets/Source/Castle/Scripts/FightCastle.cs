using UnityEngine;
using UnityEngine.Events;

public class FightCastle : MonoBehaviour
{
    [SerializeField] private Tower _mainTower;
    [SerializeField] private TargetsPool _targetsPool;
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private Tower _towerPrefab;

    private CastleFightStats _castleStats;
    private bool _towersSpawned = false;

    public bool TowersSpawned => _towersSpawned;

    public void ApplyProgress(CastleFightStats castleStats)
    {
        _castleStats = castleStats;

        TowerStats mainTowerStats = _castleStats.CalculateMainTowerStats();
        _mainTower.SetStats(mainTowerStats);
        _targetsPool.AddObject(_mainTower);

        int amount = _castleStats.AdditionalTowers;
        TowerStats towerStats = _castleStats.CalculateTowerStats();

        if (amount > 0)
            _towerSpawner.Spawn(_towerPrefab, amount, towerStats);

        _towersSpawned = true;
    }
}
