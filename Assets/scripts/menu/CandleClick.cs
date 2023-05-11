using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleClick : MonoBehaviour
{
    public int id;
    public mainMenuCamScript camScript;
    public Light flame;
    public float LightUpper;
    public float LightLower;
    public float boost;
    private bool Increasing;

    private bool isChangingIntensity = true;

    private void Start()
    {
        flame = this.gameObject.transform.GetChild(0).transform.GetComponent<Light>();
        LightUpper = flame.intensity + 0.4f;
        LightLower = flame.intensity - 0.4f;
        Increasing = true;
        boost = 0f;

        LeanTween.value(flame.gameObject, -2, 2.8f, 5).setOnUpdate(setRange);
    }

    public void setRange(float range)
	{
        flame.range = range;

        if(flame.range > 2.5f)
		{
            camScript.glowed = true;
		}
	}

    private void Update()
    {


        if (camScript.CandleFlicker == this.gameObject.GetComponent<CandleClick>())
        {
            if (flame.intensity < LightUpper+boost && Increasing)
            {
                flame.intensity += 0.1f*Time.deltaTime;

            }
            else if (flame.intensity > LightLower+boost && !Increasing)
            {
                flame.intensity -= 0.1f*Time.deltaTime;
            }
            if (flame.intensity >= LightUpper+boost)
            {
                flame.intensity = LightUpper+boost;
                Increasing = false;
            }
            else if (flame.intensity <= LightLower+boost)
            {
                flame.intensity = LightLower+boost;
                Increasing = true;
            }
        }
    }

}
