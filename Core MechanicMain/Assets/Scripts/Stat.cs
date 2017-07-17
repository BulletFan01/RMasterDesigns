using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private float maxValue;

    [SerializeField]
    private float currentValue;

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {          
            currentValue = value;
            bar.Value = currentValue;
        }
    }

    public float MaxValue
    {
        get
        {
            return maxValue;
        }

        set
        {
            maxValue = value;
            GetBar().MaxValue = maxValue;
        }
    }

    private BarScript GetBar()
    {
        return bar;
    }

    public void Initialize()
    {
        this.MaxValue = maxValue;
        this.CurrentValue = currentValue;
    }
}
