using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderView))]
public class MusicLevelController : MonoBehaviour
{
    [SerializeField] private SettingsApplier _settingsApplier;

    private SliderView _view;

    private void Awake()
    {
        _view = GetComponent<SliderView>();
    }

    private void OnEnable()
    {
        _view.SetValue(SettingsApplier.MusicLevel);
    }

    private void Update()
    {
        _settingsApplier.SetMusicSettings((int)_view.Value);
    }
}
