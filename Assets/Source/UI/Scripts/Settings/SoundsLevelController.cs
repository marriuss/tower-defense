using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SoundsLevelController : MonoBehaviour
{
    [SerializeField] private SettingsApplier _settingsApplier;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.value = SettingsApplier.SoundsLevel;
        _slider.onValueChanged.AddListener(OnValueChange);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnValueChange);
    }

    private void OnValueChange(float newValue)
    {
        _settingsApplier.SetSoundsSettings((int)newValue);
    }
}