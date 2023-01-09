public class PlayerProgress
{
    public int Money;
    public int LastLevelId;
    public CardProgress[] CardProgress;
    public int?[] CardIds;
    public int CastleLevel;

    public Balance Balance;
    public CastleStats CastleStats;

    public PlayerProgress()
    {
        // TODO: Create default if save not found!
        Balance = new Balance(Money);
        CastleStats = new CastleStats(CastleLevel);
    }
}