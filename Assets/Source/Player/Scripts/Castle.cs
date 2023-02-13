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
        int a = _castleUpgrade.GetAdditionalTowersAmountByLevel(0);
        int a1 = _castleUpgrade.GetAdditionalTowersAmountByLevel(20);
        int a2 = _castleUpgrade.GetAdditionalTowersAmountByLevel(40);
        int a3 = _castleUpgrade.GetAdditionalTowersAmountByLevel(60);
        int a4 = _castleUpgrade.GetAdditionalTowersAmountByLevel(80);
        int a5 = _castleUpgrade.GetAdditionalTowersAmountByLevel(100);
        float b = _castleUpgrade.GetTowerHealthFractionByLevel(0);
        float b1 = _castleUpgrade.GetTowerHealthFractionByLevel(20);
        float b2 = _castleUpgrade.GetTowerHealthFractionByLevel(40);
        float b3 = _castleUpgrade.GetTowerHealthFractionByLevel(60);
        float b4 = _castleUpgrade.GetTowerHealthFractionByLevel(80);
        float b5 = _castleUpgrade.GetTowerHealthFractionByLevel(100);
    }
}
