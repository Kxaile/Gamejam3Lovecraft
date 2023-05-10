using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuCamScript : MonoBehaviour
{
    public GameObject LastHit;  //Last hit is stored so that the candle can be turned off, since raycast hit is lost when deselected
    public LayerMask mask;
    public Canvas SettingsCanvas;
    bool highlighted;
    bool AllowRaycast;
    private int Id;
    public Light hitLight;
    public CandleClick CandleFlicker;

    public void SetAllowRaycast(bool boolean)
    {
        AllowRaycast = boolean;
    }
    void Start()
    {
        LastHit = null;
        AllowRaycast = true;
    }


    void Update()
    {
        if (AllowRaycast) { 
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (highlighted && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Id = LastHit.transform.GetComponent<CandleClick>().id;
                print(Id);

                switch (Id)
                {
                    case 0: LastHit.transform.GetComponent<SceneSwtich>().ChangeScene(1);
                        break;
                    case 1: SettingsCanvas.transform.gameObject.SetActive(true);
                        AllowRaycast = false;
                        break;
                    case 2:LastHit.transform.GetComponent<SceneSwtich>().Exit();
                        break;
                }

            }
            if (Physics.Raycast(ray, out hit, 25f, mask) && LastHit == null)
            {
                //brighten hit candle 
                CandleFlicker = hit.transform.GetComponent<CandleClick>();


                CandleFlicker.boost = 1f;
                CandleFlicker.flame.range = 6;

                highlighted = true;

                LastHit = hit.transform.gameObject;
            }
            else if (!(Physics.Raycast(ray, out hit, 25f, mask)) && LastHit != null)
            {
                //dim last candle 
                CandleFlicker = LastHit.transform.GetComponent<CandleClick>() ;
                CandleFlicker.boost = 0;
                CandleFlicker.flame.intensity = 1f;
                CandleFlicker.flame.range = 4;

                CandleFlicker = null;

                highlighted = false;

                LastHit = null;
            }
        }
    }
}
