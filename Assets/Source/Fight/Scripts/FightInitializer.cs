using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FightInitializer : MonoBehaviour
{
    [SerializeField] private CardStack _cardStack;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private FightCastle _castle;
    [SerializeField] private TowerSpawner _towerSpawner;

    public void Initialize(FightInfo fightInfo)
    {
        LevelInfo levelInfo = fightInfo.LevelInfo;
        Zone zone = levelInfo.Zone;

        InitializeCardStack(fightInfo.Deck, levelInfo.CardStackCapacity);
        InitializeEnemySpawner(zone, levelInfo.Waves);
        InitializeCastle(fightInfo.CastleStats);
    }

    private void InitializeCardStack(Deck deck, int cardStackCapacity)
    {
        HashSet<Card> cardSet = deck.Cards.Where(card => card != null).ToHashSet();
        _cardStack.GenerateStack(cardSet, cardStackCapacity);
    }

    private void InitializeEnemySpawner(Zone zone, List<Wave> waves)
    {
        _enemySpawner.StartSpawn(zone.WavesDelay, zone.SpawnDelay, waves);
    }

    private void InitializeCastle(CastleFightStats castleStats)
    {
        _castle.ApplyProgress(castleStats);
    }
}
