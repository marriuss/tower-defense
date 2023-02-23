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
#if UNITY_WEBGL && !UNITY_EDITOR
        yield return YandexGamesSdk.Initialize();
#endif

        LoadSettings();
        SettingsInitialized = true;

        LoadPlayer();
        GameInitialized = true;

        yield return null;
    }

    private void LoadSettings()
    {
        LeanLanguage language = null;
        string languageName = _playerPrefSettings.TryLoadLanguageSettings();

#if UNITY_WEBGL && !UNITY_EDITOR
        if (YandexGamesSdk.IsInitialized && string.IsNullOrEmpty(languageName))
            language = _languageIdentifier.IdentifyLanguageByCode(YandexGamesSdk.Environment.i18n.lang);
#endif

        if (language == null)
            language = _languageIdentifier.IdentifyLanguageByName(languageName);

        _settingsApplyier.SetLanguageSettings(language.name);

        int? musicLevel = _playerPrefSettings.TryLoadMusicSettings();
        int musicSettings = musicLevel == null ? _defaultSettings.MusicLevel : musicLevel.Value;
        _settingsApplyier.SetMusicSettings(musicSettings);

        int? soundsLevel = _playerPrefSettings.TryLoadSoundsSettings();
        int soundsSettings = soundsLevel == null ? _defaultSettings.SoundsLevel : soundsLevel.Value;
        _settingsApplyier.SetSoundsSettings(soundsSettings);
    }

    private void LoadPlayer()
    {
        _playerProgressStorage.SetDefaultData(_defaultCards);
        _playerProgressStorage.LoadData();
    }
}
