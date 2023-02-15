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
    [SerializeField] private Settings _settings;
    [SerializeField] private List<CardInfo> _defaultCards;

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
        _settings.SetLanguage(_languageIdentifier.IdentifyLanguageByCode(languageCode));
        _playerPrefSettings.SaveLanguageSettings(_settings.Language.TranslationCode);

        float? musicLevel = _playerPrefSettings.TryLoadMusicSettings();

        if (musicLevel != null)
            _settings.SetMusicLevel(musicLevel.Value);

        float? soundsLevel = _playerPrefSettings.TryLoadSoundsSettings();

        if (soundsLevel != null)
            _settings.SetSoundsLevel(soundsLevel.Value);
    }

    private void LoadPlayer()
    {
        _playerProgressStorage.LoadData(_defaultCards);
    }
}
