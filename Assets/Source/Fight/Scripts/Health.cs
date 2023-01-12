using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public int MaxValue { get; private set; }
    public int Value { get; private set; }

    public Health(int maxHealth)
    {
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
        Value += value;
    }

    public void DecreaseValue(int value)
    {
        Value -= value;
    }
}
