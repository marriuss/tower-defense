using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInfo
{
    public Deck Deck { get; private set; }
    public LevelInfo LevelInfo { get; private set; }
    public CastleStats CastleStats { get; private set; }

    public FightInfo(Deck deck, LevelInfo levelInfo, CastleStats castleStats)
    {
        Deck = deck;
        LevelInfo = levelInfo;
        CastleStats = castleStats;
    }
}
