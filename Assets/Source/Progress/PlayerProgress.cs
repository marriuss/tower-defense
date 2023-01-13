public class PlayerProgress
{
    public int Money;
    public int LastLevelId;
    public CardProgress[] CardsProgress;
    public int?[] CardIds;
    public int CastleLevel;
    public CastleProgress CastleProgress;

    public PlayerProgress(int money, int lastLevelId, CardProgress[] cardsProgress, int?[] cardIds, int castleLevel, CastleProgress castleProgress)
    {
        Money = money;
        LastLevelId = lastLevelId;
        CardsProgress = cardsProgress;
        CardIds = cardIds;
        CastleLevel = castleLevel;
        CastleProgress = castleProgress;
    }

    public PlayerProgress()
    {
        Money = 0;
        LastLevelId = 1;
        CardsProgress = new CardProgress[0];
        CardIds = new int?[0];
        CastleLevel = 1;
        CastleProgress = new CastleProgress();
    }
}