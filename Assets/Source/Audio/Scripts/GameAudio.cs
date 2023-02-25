using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioMixerController _musicMixer;
    [SerializeField] private AudioMixerController _soundsMixer;

    private bool _muted;

    private void OnApplicationFocus(bool focus)
    {
        if (focus && _muted == false)
        {
            Unmute();
        }
        else
        {
            Mute();
        }
    }

    public void SetMusicVolume(int index)
    {
        _musicMixer.SetVolume(index);
    } 

    public void MuteMusic()
    {
        _muted = true;
        Mute();
    }

    public void UnmuteMusic()
    {
        _muted = false;
        Unmute();
    }

    public void SetSoundsVolume(int index)
    {
        _soundsMixer.SetVolume(index);
    }

    private void Mute()
    {
        _musicMixer.Mute();
    }

    private void Unmute()
    {
        _musicMixer.Unmute();
    }
}
