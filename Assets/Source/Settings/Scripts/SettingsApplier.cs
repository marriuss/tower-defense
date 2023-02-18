using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class SettingsApplier : MonoBehaviour
{
    [SerializeField] private LeanLocalization _lean;
    [SerializeField] private GameAudio _audio;
    [SerializeField] private PlayerPrefSettings _playerPrefsSettings;

    public static float MusicLevel { get; private set; }
    public static float SoundsLevel { get; private set; }
    public static string Language { get; private set; }

    private void Start()
    {
        ApplySettings();
    }

    public void ApplySettings()
    {
        ApplyLanguageSettings();
        ApplyMusicSettings();
        ApplySoundsSettings();
    }

    public void SetLanguageSettings(string leanLanguage)
    {
        if (Language == leanLanguage)
            return;

        Language = leanLanguage;
        _playerPrefsSettings.SaveLanguageSettings(leanLanguage);
        ApplyLanguageSettings();
    }

    public void SetMusicSettings(float musicLevel)
    {
        if (MusicLevel == musicLevel)
            return;

        MusicLevel = musicLevel;
        _playerPrefsSettings.SaveMusicSettings(musicLevel);
        ApplyMusicSettings();
    }

    public void SetSoundsSettings(float soundsLevel)
    {
        if (SoundsLevel == soundsLevel)
            return;

        SoundsLevel = soundsLevel;
        _playerPrefsSettings.SaveSoundsSettings(soundsLevel);
        ApplySoundsSettings();
    }

    private void ApplyLanguageSettings()
    {
        if (Language != null)
            _lean.SetCurrentLanguage(Language);
    }

    private void ApplyMusicSettings() => _audio.SetMusicVolume(MusicLevel);

    private void ApplySoundsSettings() => _audio.SetSoundsVolume(SoundsLevel);
}
