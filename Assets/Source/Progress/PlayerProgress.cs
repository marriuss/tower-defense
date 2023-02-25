public class PlayerProgress
{
    public int Money;
    public int LastLevelId;
    public CardProgress[] OpenCardsProgress;
    public int CastleLevel;

    public PlayerProgress(int money, int lastLevelId, CardProgress[] openCardsProgress, int castleLevel)
    {
        Money = money;
        LastLevelId = lastLevelId;
        OpenCardsProgress = openCardsProgress;
        CastleLevel = castleLevel;
    }
}