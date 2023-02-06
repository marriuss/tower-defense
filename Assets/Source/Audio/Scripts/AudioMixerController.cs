using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private const float MinVolume = -80;
    private const float MaxVolume = 20;
    private const float VolumeRange = MaxVolume - MinVolume;
    private const string VolumeParameter = "Volume";

    private bool _mute;
    private float _volume;

    public void SetVolume(float volume)
    {
        volume = VolumeRange * (Mathf.Clamp01(volume) - 1) + MaxVolume;
        _volume = volume;

        if (_mute == false)
            SetMixerVolume(_volume);
    }

    public void Mute()
    {
        _mute = true;
        SetMixerVolume(MinVolume);
    }

    public void Unmute()
    {
        _mute = false;
        SetMixerVolume(_volume);
    }

    private void SetMixerVolume(float volume)
    {
        _mixer.SetFloat(VolumeParameter, volume);
    }
}
