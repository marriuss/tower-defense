using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    public const int MinVolumeIndex = 0;
    public const int MaxVolumeIndex = 4;

    private const string VolumeParameter = "Volume";

    private float[] _volumes = { -80, -20, -10, -3, 0 };

    private bool _mute;
    private int _volumeIndex;

    public void SetVolume(int index)
    {
        _volumeIndex = Mathf.Clamp(index, MinVolumeIndex, MaxVolumeIndex);

        if (_mute == false)
            SetMixerVolume(_volumeIndex);
    }

    public void Mute()
    {
        _mute = true;
        SetMixerVolume(MinVolumeIndex);
    }

    public void Unmute()
    {
        _mute = false;
        SetMixerVolume(_volumeIndex);
    }

    private void SetMixerVolume(int index)
    {
        float volume = _volumes[index];
        _mixer.SetFloat(VolumeParameter, volume);
    }
}
