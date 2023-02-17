using UnityEngine.Events;

public class Castle
{
    private const int StartLevel = 1;
    private const int MaxLevel = 100;

    private CastleUpgradeCalculator _castleUpgrade;

    public int Level { get; private set; }
    public int Health { get; private set; }
    public int AdditionalTowersAmount { get; private set; }
    public int TowerHealthFraction { get; private set; }
    public int UpgradeCost { get; private set; }

    public event UnityAction StatsChanged;

    public Castle() : this(StartLevel) { }

    public Castle(int level)
    {
        _castleUpgrade = new CastleUpgradeCalculator();
        ApplyLevelStats(level);
    }

    public bool CanUpgrade => Level < MaxLevel;

    public void Upgrade()
    {
        ApplyLevelStats(Level + 1);
        StatsChanged?.Invoke();
    }

    private void ApplyLevelStats(int level)
    {
        Level = level;
        InitStats();
    }

    private void InitStats()
    {
        Health = _castleUpgrade.GetHealthByLevel(Level);
        UpgradeCost = _castleUpgrade.GetUpgradeCostByLevel(Level);
    }
}
