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

    public void LoadData(List<CardInfo> defaultCards)
    {
        bool usePrefs = true;
        bool hasSavings = false;

#if UNITY_WEBGL && !UNITY_EDITOR
    if (YandexGamesSdk.IsInitialized)
    {
        if (PlayerAccount.IsAuthorized)
        {
            usePrefs = false;
            hasSavings = true;
            PlayerAccount.GetPlayerData(onSuccessCallback: LoadJsonData);
        }
    }
#endif

        if (usePrefs && PlayerPrefs.HasKey(JsonDataKey))
        {
            hasSavings = true;
            LoadJsonData(PlayerPrefs.GetString(JsonDataKey));
        }

        if (hasSavings == false)
        {
            int i = 0;
            List<DeckItem> deckItems = new List<DeckItem>();

            foreach (CardInfo cardInfo in defaultCards)
            {
                Card card = _cardsPool.FindCardByCardInfo(cardInfo);
                deckItems.Add(new DeckItem(card, i));
                i++;
            }

            Deck deck = new Deck(deckItems);
            Balance balance = new Balance();
            Castle castle = new Castle();

            _player.Initialize(deck, balance, castle);
        }
    }

    public void SaveBalance()
    {
        SaveDataOnChange(() =>
        {
            currentData.Money = GetNewMoney();
        });
    }

    public void SaveCastleStats()
    {
        SaveDataOnChange(() =>
        {
            currentData.CastleLevel = GetNewCastleLevel();
        });
    }

    public void SaveCardsProgress()
    {
        SaveDataOnChange(() =>
        {
            currentData.OpenCardsProgress = GetNewCardsProgress();
        });
    }

    public void SaveLastLevelId()
    {
        SaveDataOnChange(() =>
        {
            currentData.LastLevelId = GetNewLastLevelId();
        });
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
