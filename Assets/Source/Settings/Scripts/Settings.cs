using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

[CreateAssetMenu(fileName ="Settings", menuName ="Settings/Create")]
public class Settings : ScriptableObject
{
    [SerializeField] private LeanLanguage _language;
    [SerializeField, Range(AudioMixerController.MinVolumeIndex, AudioMixerController.MaxVolumeIndex)] private int _soundsLevel;
    [SerializeField, Range(AudioMixerController.MinVolumeIndex, AudioMixerController.MaxVolumeIndex)] private int _musicLevel;

    public LeanLanguage Language => _language;
    public int SoundsLevel => _soundsLevel;
    public int MusicLevel => _musicLevel;
}
