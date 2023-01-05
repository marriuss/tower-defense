public class CastleStats
{
    private const int StartLevel = 1;

    public int Level;
    public int Health;
    public int Damage;
    public int Population;
    public int GuardHealth;
    public int GuardDamage;
    public int UpgradeCost;

    private CastleUpgradeCalculator _castleUpgrade;

    public CastleStats() : this(StartLevel) { }

    public CastleStats(int level)
    {
        Level = level;
        _castleUpgrade = new CastleUpgradeCalculator();
        InitStats(_castleUpgrade);
    }

    public void Upgrade()
    {
        Level++;
        InitStats(_castleUpgrade);
    }

    private void InitStats(CastleUpgradeCalculator mainHouseUpgrade)
    {
        Health = _castleUpgrade.GetHealthByLevel(Level);
        Damage = _castleUpgrade.GetDamageByLevel(Level);
        Population = _castleUpgrade.GetPopulationByLevel(Level);
        GuardHealth = _castleUpgrade.GetGuardHealthByLevel(Level);
        GuardDamage = _castleUpgrade.GetGuardDamageByLevel(Level);
        UpgradeCost = _castleUpgrade.GetUpgradeCostByLevel(Level);
    }
}
