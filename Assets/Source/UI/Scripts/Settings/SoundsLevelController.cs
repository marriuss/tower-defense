using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderView))]
public class SoundsLevelController : MonoBehaviour
{
    [SerializeField] private SettingsApplier _settingsApplier;
    
    private SliderView _view;

    private void Awake()
    {
        _view = GetComponent<SliderView>();
    }

    private void OnEnable()
    {
        _view.SetValue(SettingsApplier.SoundsLevel);
    }

    private void Update()
    {
        _settingsApplier.SetSoundsSettings((int)_view.Value);
    }
}
