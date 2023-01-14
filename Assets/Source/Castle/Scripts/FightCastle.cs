using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Tower))]
public class FightCastle : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private Tower _towerPrefab;

    private CastleFightStats _castleStats;
    private Tower _tower;

    private void Awake()
    {
        _tower = GetComponent<Tower>();
    }

    public void ApplyProgress(CastleFightStats castleStats)
    {
        _castleStats = castleStats;
        _towerSpawner.AddMainTower(_tower);
        int amount = _castleStats.AdditionalTowers;

        if (amount > 0)
            _towerSpawner.Spawn(_towerPrefab, amount);
    }
}
