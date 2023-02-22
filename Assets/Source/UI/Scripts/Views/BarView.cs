using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BarView : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.wholeNumbers = false;  
    }

    private void Start()
    {
        _slider.value = 0;
    }

    public void SetLimits(RangeInt range)
    {
        _slider.minValue = range.start;
        _slider.maxValue = range.end;
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }
}
