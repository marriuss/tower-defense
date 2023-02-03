using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class SettingsApplier : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    [SerializeField] private GameAudio _audio;

    private void Update()
    {
        LeanLocalization.SetCurrentLanguageAll(_settings.Language.name);
        _audio.SetMusicVolume(_settings.MusicLevel);
        _audio.SetSoundsVolume(_settings.SoundsLevel);
    }
}
