using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;
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
    [SerializeField] private AutoTiler _autoTiler;
    [SerializeField, Min(1)] private float _cameraBoundsExtensionScale;

    private Rect _boundsRect;

    private void Awake()
    {
        _boundsRect = _battlefield.BattlefieldRect;
        _boundsRect.Set(
            _boundsRect.x * _cameraBoundsExtensionScale,
            _boundsRect.y * _cameraBoundsExtensionScale,
            _boundsRect.width * _cameraBoundsExtensionScale,
            _boundsRect.height * _cameraBoundsExtensionScale
            );

        InitializeCameraMovement(_boundsRect);
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
        InitializeLevelPalette(_boundsRect, zone.Palette.DefaultTile, zone.Palette.BattlefieldTiles);
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

    private void InitializeCameraMovement(Rect bounds)
    {
        _cameraMovement.SetRectBounds(bounds);
    }

    private void InitializeReward(int moneyReward)
    {
        _rewardAccounter.SetMoneyReward(moneyReward);
    }
    
    private void InitializeLevelPalette(Rect bounds, TileBase defaultTile, IReadOnlyList<TileBase> tiles)
    {
        _autoTiler.FillRect(bounds, defaultTile, tiles);
    }
}
