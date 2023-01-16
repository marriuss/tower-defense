using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Tower))]
public class FightCastle : MonoBehaviour
{
    [SerializeField] private Tower _mainTower;
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private Tower _towerPrefab;

    private CastleFightStats _castleStats;

    public void ApplyProgress(CastleFightStats castleStats)
    {
        _castleStats = castleStats;
        _towerSpawner.AddMainTower(_mainTower);
        int amount = _castleStats.AdditionalTowers;

        if (amount > 0)
            _towerSpawner.Spawn(_towerPrefab, amount);
    }
}
