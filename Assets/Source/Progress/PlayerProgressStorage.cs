using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using System.Linq;

public class PlayerProgressStorage : MonoBehaviour
{
    [SerializeField] private Player _player;

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
        int castleLevel = playerProgress.CastleLevel;

        Balance balance = new Balance(money);
        Deck deck = new Deck();
        Castle castle = new Castle(castleLevel);

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

        return new PlayerProgress();
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
