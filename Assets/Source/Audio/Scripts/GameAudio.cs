using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioMixerController _musicMixer;
    [SerializeField] private AudioMixerController _soundsMixer;

    public void SetMusicVolume(float volume)
    {
        _musicMixer.SetVolume(volume);
    } 

    public void MuteMusic()
    {
        _musicMixer.Mute();
    }

    public void UnmuteMusic()
    {
        _musicMixer.Unmute();
    }

    public void SetSoundsVolume(float volume)
    {
        _soundsMixer.SetVolume(volume);
    }
}
