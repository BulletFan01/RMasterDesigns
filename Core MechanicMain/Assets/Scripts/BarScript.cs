using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    //Can be updated when health is increased
    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = HealthExchange(value);
           //fillAmount = MapBar(value, 0, MaxValue, 0, 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        if(fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    private float HealthExchange(float health)
    {
        float fillVal = health * 0.01f;

        return fillVal;
    }


    //Use later for BOSS health
    private float MapBar(float value, float minIn, float maxIn, float minOut, float maxOut)
    {
        return (value - minIn) * (maxOut - minOut) / (maxIn - minIn) + maxOut;
    }

}
