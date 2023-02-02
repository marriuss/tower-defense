using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using Agava.YandexGames;

public class Initializer : MonoBehaviour
{
    [SerializeField] private LanguageIdentifier _languageIdentifier;
    [SerializeField] private PlayerPrefSettings _playerPrefSettings;
    [SerializeField] private Settings _settings;
    [SerializeField] private MapSceneLoader _mapSceneLoader;

    private void Awake()
    {
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

        _settings.SetLanguage(_languageIdentifier.IdentifyLanguageByCode(languageCode));
        _playerPrefSettings.SaveLanguageSettings(_settings.Language.TranslationCode);

        float? musicLevel = _playerPrefSettings.TryLoadMusicSettings();
        
        if (musicLevel != null)
            _settings.SetMusicLevel(musicLevel.Value);

        float? soundsLevel = _playerPrefSettings.TryLoadSoundsSettings();

        if (soundsLevel != null)
            _settings.SetSoundsLevel(soundsLevel.Value);

        _mapSceneLoader.LoadMapScene();

        yield return null;
    }
}
