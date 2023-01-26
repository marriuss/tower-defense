using UnityEngine;
using UnityEngine.Events;

public class FightCastle : MonoBehaviour
{
    [SerializeField] private Tower _mainTower;
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private Tower _towerPrefab;

    private CastleFightStats _castleStats;

    public event UnityAction SpawnedTowers;

    public void ApplyProgress(CastleFightStats castleStats)
    {
        _castleStats = castleStats;

        TowerStats mainTowerStats = _castleStats.CalculateMainTowerStats();
        _mainTower.SetStats(mainTowerStats);
        _towerSpawner.AddMainTower(_mainTower);

        int amount = _castleStats.AdditionalTowers;
        TowerStats towerStats = _castleStats.CalculateTowerStats();

        if (amount > 0)
            _towerSpawner.Spawn(_towerPrefab, amount, towerStats);

        SpawnedTowers?.Invoke();
    }
}
