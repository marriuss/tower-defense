using Lean.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerPrefSettings : MonoBehaviour
{
    private const string LanguageSettings = "languageCode";
    private const string MusicSettings = "music";
    private const string SoundsSettings = "sounds";

    public string TryLoadLanguageSettings()
    {
        return TryLoadSettings<string>(LanguageSettings, () => PlayerPrefs.GetString(LanguageSettings));
    }

    public float? TryLoadSoundsSettings()
    {
        return TryLoadSettings<float?>(SoundsSettings, () => PlayerPrefs.GetFloat(SoundsSettings));
    }

    public float? TryLoadMusicSettings()
    {
        return TryLoadSettings<float?>(MusicSettings, () => PlayerPrefs.GetFloat(MusicSettings));
    }

    public void SaveLanguageSettings(string languageCode)
    {
        SaveSettings(PlayerPrefs.SetString, LanguageSettings, languageCode);
    }

    public void SaveMusicSettings(float musicLevel)
    {
        SaveSettings(PlayerPrefs.SetFloat, MusicSettings, musicLevel);
    }

    public void SaveSoundsSettings(float soundsLevel)
    {
        SaveSettings(PlayerPrefs.SetFloat, SoundsSettings, soundsLevel);
    }

    private T TryLoadSettings<T>(string key, Func<T> action)
    {
        T result = default;

        if (PlayerPrefs.HasKey(key))
        {
            result = action.Invoke();

        }

        return result;
    }

    private void SaveSettings<T>(Action<string, T> action, string key, T value)
    {
        action.Invoke(key, value);
        PlayerPrefs.Save();
    }
}