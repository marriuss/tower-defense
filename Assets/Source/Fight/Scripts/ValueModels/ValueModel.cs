using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ValueModel
{
    private int _value;

    public int MaxValue { get; private set; }
    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            value = Mathf.Clamp(value, 0, MaxValue);
            _value = value;
        }
    }

    public event UnityAction ValueChanged;

    public ValueModel(int startValue, int maxValue)
    {
        ThrowExceptionIfNegative(startValue);
        ThrowExceptionIfNegative(maxValue);

        MaxValue = maxValue;
        Value = startValue;
    }

    public ValueModel(int maxValue)
    {
        ThrowExceptionIfNegative(maxValue);

        MaxValue = maxValue;
        Value = maxValue;
    }

    public ValueModel()
    {
        MaxValue = 0;
        Value = 0;
    }

    public void IncreaseValue(int value)
    {
        ThrowExceptionIfNegative(value);

        ChangeValue(Value + value);
    }

    public void DecreaseValue(int value)
    {
        ThrowExceptionIfNegative(value);

        ChangeValue(Value - value);
    }

    private void ChangeValue(int newValue)
    {
        Value = newValue;
        ValueChanged?.Invoke();
    }

    private void ThrowExceptionIfNegative(int value)
    {
        if (value < 0)
            throw new NegativeArgumentException();
    }
}
