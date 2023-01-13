using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health
{
    private int _health;

    public int MaxValue { get; private set; }
    public int Value
    {
        get
        {
            return _health;
        }
        set
        {
            value = Math.Clamp(value, 0, MaxValue);
            _health = value;
        }
    }

    public event UnityAction ValueChanged;

    public Health(int maxHealth)
    {
        ThrowExceptionIfNegative(maxHealth);

        MaxValue = maxHealth;
        Value = maxHealth;
    }

    public Health()
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

public class NegativeArgumentException : Exception
{
    private const string ExceptionMessage = "Argument cannot be negative.";

    public NegativeArgumentException() : base(ExceptionMessage) { }
}
