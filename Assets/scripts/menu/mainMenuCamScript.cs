using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise.Editor;
using AK.Wwise;

public class mainMenuCamScript : MonoBehaviour
{
    public GameObject LastHit;
    public LayerMask mask;
    public Canvas SettingsCanvas;
    bool highlighted;
    bool AllowRaycast;
    private int Id;
    private Light light;

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
                light = hit.transform.GetChild(0).gameObject.transform.GetComponent<Light>();

                print(light.intensity.ToString());

                light.intensity = 2f;
                light.range = 6f;

                highlighted = true;

                LastHit = hit.transform.gameObject;
            }
            else if (!(Physics.Raycast(ray, out hit, 25f, mask)) && LastHit != null)
            {
                //dim last candle 
                light = LastHit.transform.GetChild(0).gameObject.transform.GetComponent<Light>();

                light.intensity = 1f;
                light.range = 4f;


                highlighted = false;

                LastHit = null;
            }
        }
    }
}
