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


    private void Start()
    {
        flame = this.gameObject.transform.GetChild(0).transform.GetComponent<Light>();
        LightUpper = flame.intensity + 0.4f;
        LightLower = flame.intensity - 0.4f;
        Increasing = true;
        boost = 0f; 
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
