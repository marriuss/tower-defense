using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using IJunior.TypedScenes;

public class FightInitializer : MonoBehaviour, ISceneLoadHandler<FightInfo>
{
    [SerializeField] private Battlefield _battlefield;
    [SerializeField] private CardStack _cardStack;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private FightCastle _castle;
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private RewardAccounter _rewardAccounter;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField, Min(1)] private float _cameraBoundsExtensionScale;

    private void Awake()
    {
        InitializeCameraMovement();
    }

    public void OnSceneLoaded(FightInfo argument)
    {
        Initialize(argument);
    }

    public void Initialize(FightInfo fightInfo)
    {
        LevelInfo levelInfo = fightInfo.LevelInfo;
        Zone zone = levelInfo.Zone;

        InitializeCardStack(fightInfo.Deck, levelInfo.CardStackCapacity);
        InitializeEnemySpawner(zone, levelInfo.Waves);
        InitializeCastle(fightInfo.CastleStats);
        InitializeReward(levelInfo.MoneyReward);
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

    private void InitializeCameraMovement()
    {
        Rect battlefieldRect = _battlefield.BattlefieldRect;
        battlefieldRect.Set(
            battlefieldRect.x * _cameraBoundsExtensionScale,
            battlefieldRect.y * _cameraBoundsExtensionScale,
            battlefieldRect.width * _cameraBoundsExtensionScale,
            battlefieldRect.height * _cameraBoundsExtensionScale
            );

        _cameraMovement.SetRectBounds(battlefieldRect);
    }
    
    private void InitializeReward(int moneyReward)
    {
        _rewardAccounter.SetMoneyReward(moneyReward);
    }
}