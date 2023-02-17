using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using Agava.YandexGames;

public class Initializer : MonoBehaviour
{
    [SerializeField] private LanguageIdentifier _languageIdentifier;
    [SerializeField] private PlayerProgressStorage _playerProgressStorage;
    [SerializeField] private PlayerPrefSettings _playerPrefSettings;
    [SerializeField] private Settings _defaultSettings;
    [SerializeField] private List<CardInfo> _defaultCards;
    [SerializeField] private SettingsApplier _settingsApplyier;

    public bool GameInitialized { get; private set; }
    public bool SettingsInitialized { get; private set; }

    private void Awake()
    {
        GameInitialized = false;
        SettingsInitialized = false;
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        string languageCode = _playerPrefSettings.TryLoadLanguageSettings();

#if UNITY_WEBGL && !UNITY_EDITOR
        yield return YandexGamesSdk.Initialize();
        
        if (string.IsNullOrEmpty(languageCode))
            languageCode = YandexGamesSdk.Environment.i18n.lang;
#endif
        LoadSettings(languageCode);
        SettingsInitialized = true;

        LoadPlayer();
        GameInitialized = true;

        yield return null;
    }

    private void LoadSettings(string languageCode)
    {
        LeanLanguage language = _languageIdentifier.IdentifyLanguageByCode(languageCode);
        _settingsApplyier.SetLanguageSettings(language);

        float? musicLevel = _playerPrefSettings.TryLoadMusicSettings();
        float musicSettings = musicLevel == null ? _defaultSettings.MusicLevel : musicLevel.Value;
        _settingsApplyier.SetMusicSettings(musicSettings);

        float? soundsLevel = _playerPrefSettings.TryLoadSoundsSettings();
        float soundsSettings = soundsLevel == null ? _defaultSettings.SoundsLevel : soundsLevel.Value;
        _settingsApplyier.SetSoundsSettings(soundsSettings);
    }

    private void LoadPlayer()
    {
        _playerProgressStorage.SetDefaultData(_defaultCards);
        _playerProgressStorage.LoadData();
    }
}
