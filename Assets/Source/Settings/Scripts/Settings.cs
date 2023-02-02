using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

[CreateAssetMenu(fileName ="Settings", menuName ="Settings/Create")]
public class Settings : ScriptableObject
{
    [SerializeField] private LeanLanguage _language;
    [SerializeField, Range(0, 1)] private float _soundsLevel;
    [SerializeField, Range(0, 1)] private float _musicLevel;

    public LeanLanguage Language => _language;
    public float SoundsLevel => _soundsLevel;
    public float MusicLevel => _musicLevel;

    public void SetLanguage(LeanLanguage leanLanguage)
    {
        _language = leanLanguage;
    }

    public void SetSoundsLevel(float soundsLevel)
    {
        _soundsLevel = Mathf.Clamp01(soundsLevel);
    }

    public void SetMusicLevel(float musicLevel)
    {
        _musicLevel = Mathf.Clamp01(musicLevel);
    }
}
