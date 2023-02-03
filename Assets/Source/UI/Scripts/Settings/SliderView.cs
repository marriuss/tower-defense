using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderView : MonoBehaviour
{
    private Slider _slider;

    public float Value { get; private set; }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnValueChange);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnValueChange);
    }

    public void SetValue(float newValue)
    {
        _slider.value = newValue;
    }

    private void OnValueChange(float newValue)
    {
        Value = newValue;
    }
}
