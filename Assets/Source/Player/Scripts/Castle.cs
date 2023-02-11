public class Castle
{
    private const int StartLevel = 1;

    public int Level { get; private set; }
    public int Health { get; private set; }
    public int UpgradeCost { get; private set; }

    private CastleUpgradeCalculator _castleUpgrade;

    public Castle() : this(StartLevel) { }

    public Castle(int level)
    {
        _castleUpgrade = new CastleUpgradeCalculator();
        ApplyLevelStats(level);
    }

    public void SetLevel(int level)
    {
        ApplyLevelStats(level);
    }

    public void Upgrade()
    {
        ApplyLevelStats(Level + 1);
    }

    private void ApplyLevelStats(int level)
    {
        Level = level;
        InitStats(_castleUpgrade);
    }

    private void InitStats(CastleUpgradeCalculator mainHouseUpgrade)
    {
        Health = _castleUpgrade.GetHealthByLevel(Level);
        UpgradeCost = _castleUpgrade.GetUpgradeCostByLevel(Level);
    }
}
