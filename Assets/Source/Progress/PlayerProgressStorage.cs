using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using System;

public class PlayerProgressStorage : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CardsPool _cardsPool;
    [SerializeField] private LevelsPool _levelsPool;

    private const string JsonDataKey = "PlayerProgress";

    private static string lastSavedJsonData;
    private static PlayerProgress currentData;

    private void OnEnable()
    {
        _player.Balance.MoneyCountChanged += OnBalanceChanged;
        _player.Castle.StatsChanged += OnCastleStatsChanged;
        _player.Deck.CardsChanged += OnCardsChanged;
        _levelsPool.LastLevelChanged += OnLastLevelChanged;
    }

    private void OnDisable()
    {
        _player.Balance.MoneyCountChanged -= OnBalanceChanged;
        _player.Castle.StatsChanged -= OnCastleStatsChanged;
        _player.Deck.CardsChanged -= OnCardsChanged;
        _levelsPool.LastLevelChanged -= OnLastLevelChanged;
    }

    public void LoadData()
    {
        bool usePrefs = true;

#if UNITY_WEBGL && !UNITY_EDITOR
    if (YandexGamesSdk.IsInitialized)
    {
        if (PlayerAccount.IsAuthorized)
        {
            usePrefs = false;
            PlayerAccount.GetPlayerData(onSuccessCallback: LoadJsonData);
        }
    }
#endif

        if (usePrefs && PlayerPrefs.HasKey(JsonDataKey))
            LoadJsonData(PlayerPrefs.GetString(JsonDataKey));
    }

    private PlayerProgress GetPlayerDataFromJson(string jsonData)
    {
        return JsonUtility.FromJson<PlayerProgress>(jsonData);
    }

    private void LoadJsonData(string jsonPlayerData)
    {
        PlayerProgress playerProgress = GetPlayerDataFromJson(jsonPlayerData);
        currentData = playerProgress;

        int money = playerProgress.Money;
        Balance balance = new Balance(money);

        int castleLevel = playerProgress.CastleLevel;
        Castle castle = new Castle(castleLevel);

        CardProgress[] openCardsProgress = playerProgress.OpenCardsProgress;
        List<DeckItem> deckItems = new List<DeckItem>();

        if (openCardsProgress != null)
        {
            Card card;
            int? deckIndex;

            foreach (CardProgress cardProgress in openCardsProgress)
            {
                card = _cardsPool.FindCardById(cardProgress.Id);

                if (card != null)
                {
                    card.ApplyProgress(cardProgress.Level, cardProgress.ExperiencePoints);

                    deckIndex = cardProgress.DeckIndex;

                    if (deckIndex != null)
                        deckItems.Add(new DeckItem(card, deckIndex.Value));
                }
            }
        }

        Deck deck = new Deck(deckItems);
        _player.Initialize(deck, balance, castle);
        _levelsPool.Initialize(playerProgress.LastLevelId);
    }

    private void OnBalanceChanged(int _)
    {
        SaveDataOnChange(() =>
        {
            currentData.Money = GetNewMoney();
        });
    }

    private void OnCastleStatsChanged()
    {
        SaveDataOnChange(() =>
        {
            currentData.CastleLevel = GetNewCastleLevel();
        });
    }

    private void OnCardsChanged()
    {
        SaveDataOnChange(() =>
        {
            currentData.OpenCardsProgress = GetNewCardsProgress();
        });
    }

    private void OnLastLevelChanged()
    {
        currentData.LastLevelId = GetNewLastLevelId();
        SaveCurrentData();
    }

    private void SaveDataOnChange(Action dataChangingAction)
    {
        if (currentData != null)
        {
            dataChangingAction();
            SaveCurrentData();
        }
        else
        {
            SaveNewData();
        }
    }

    private void SaveCurrentData()
    {
        SaveData(currentData);
    }

    private void SaveNewData()
    {
        PlayerProgress playerDataObject = GetPlayerDataObject();
        SaveData(playerDataObject);
    }

    private void SaveData(PlayerProgress playerProgress)
    {
        string jsonData = JsonUtility.ToJson(playerProgress);

        if (jsonData != lastSavedJsonData)
            SaveJsonData(jsonData);
    }

    private void SaveJsonData(string jsonData)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
    if (YandexGamesSdk.IsInitialized)
    {
        if (PlayerAccount.IsAuthorized)
            PlayerAccount.SetPlayerData(jsonData);
    }
#endif

        PlayerPrefs.SetString(JsonDataKey, jsonData);
        PlayerPrefs.Save();
        lastSavedJsonData = jsonData;
    }

    private PlayerProgress GetPlayerDataObject()
    {
        int money = GetNewMoney();
        int castleLevel = GetNewCastleLevel();
        CardProgress[] cardsProgress = GetNewCardsProgress();
        int lastLevelId = GetNewLastLevelId();

        return new PlayerProgress(money, lastLevelId, cardsProgress, castleLevel);
    }

    private int GetNewMoney() => _player.Balance.Money;

    private int GetNewCastleLevel() => _player.Castle.Level;

    private CardProgress[] GetNewCardsProgress()
    {
        Deck deck = _player.Deck;
        IReadOnlyList<Card> unlockedCards = _cardsPool.UnlockedCards;
        int unlockedCardsCount = unlockedCards.Count;
        CardProgress[] cardsProgress = new CardProgress[unlockedCardsCount];
        Card card;

        for (int i = 0; i < unlockedCardsCount; i++)
        {
            card = unlockedCards[i];
            cardsProgress[i] = new CardProgress(
                card.CardInfo.Id,
                card.Level,
                card.ExperiencePoints,
                deck.GetCardIndex(card)
                );
        }

        return cardsProgress;
    }

    private int GetNewLastLevelId() => _levelsPool.LastLevelId;
}
