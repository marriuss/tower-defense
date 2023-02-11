using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using System.Linq;

public class PlayerProgressStorage : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CardsPool _cardsPool;

    private const string JsonDataKey = "PlayerProgress";

    private static string lastSavedData;

    private void OnEnable()
    {
        _player.DataChanged += OnDataChanged;
    }

    private void OnDisable()
    {
        _player.DataChanged -= OnDataChanged;
    }

    public void LoadData()
    {
        bool usePrefs = true;

#if UNITY_WEBGL && !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
        {
            usePrefs = false;
            PlayerAccount.GetPlayerData(onSuccessCallback: LoadJsonData);
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

        int money = playerProgress.Money;
        Balance balance = new Balance(money);

        int castleLevel = playerProgress.CastleLevel;
        Castle castle = new Castle(castleLevel);

        Deck deck = new Deck();
        CardProgress[] openCardsProgress = playerProgress.OpenCardsProgress;
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
                    deck.PlaceCard(card, deckIndex.Value);

            }
        }

        _player.Initialize(deck, balance, castle);
    }

    private void OnDataChanged()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerProgress playerDataObject = GetPlayerDataObject();
        string jsonData = JsonUtility.ToJson(playerDataObject);

        if (jsonData != lastSavedData)
            SaveJsonData(jsonData);
    }

    private PlayerProgress GetPlayerDataObject()
    {
        int money = _player.Balance.Money;
        int castleLevel = _player.Castle.Level;

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

        return new PlayerProgress(money, 1, cardsProgress, castleLevel);
    }

    private void SaveJsonData(string jsonData)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
            PlayerAccount.SetPlayerData(jsonData);
#endif

        PlayerPrefs.SetString(JsonDataKey, jsonData);
        PlayerPrefs.Save();
        lastSavedData = jsonData;
    }
}
