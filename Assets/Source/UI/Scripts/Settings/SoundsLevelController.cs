using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderView))]
public class SoundsLevelController : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    [SerializeField] private PlayerPrefSettings _playerPrefSettings;

    private SliderView _view;

    private void Awake()
    {
        _view = GetComponent<SliderView>();
    }

    private void OnEnable()
    {
        _view.SetValue(_settings.SoundsLevel);
    }

    private void Update()
    {
        _settings.SetMusicLevel(_view.Value);
        _playerPrefSettings.SaveMusicSettings(_settings.SoundsLevel);
    }
}
