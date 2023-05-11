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

    public textWiggle wiggle;

    public bool glowed;
    public GameObject cameraEnd;
    public GameObject door;
    public GameObject doorEnd;
    public GameObject spotlight;

    public void SetAllowRaycast(bool boolean)
    {
        AllowRaycast = boolean;
    }
    void Start()
    {
        Screen.SetResolution(640, 480, true);
        LastHit = null;
        AllowRaycast = true;
    }

    public IEnumerator startCutscene(SceneSwtich scenes)
	{
        spotlight.SetActive(true);
        LeanTween.move(door, doorEnd.transform.position, 0.8f).setEaseInCubic();
        LeanTween.rotate(door, doorEnd.transform.eulerAngles, 0.8f).setEaseInCubic();

        LeanTween.move(Camera.main.gameObject, cameraEnd.transform.position, 2f).setEaseInCubic();
        LeanTween.rotate(Camera.main.gameObject, cameraEnd.transform.eulerAngles, 2f).setEaseInCubic();
        yield return new WaitForSeconds(2f);
        scenes.ChangeScene(1);
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
                    case 0: StartCoroutine(startCutscene(LastHit.transform.GetComponent<SceneSwtich>()));
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

				if (glowed)
				{
                    wiggle.spinNchange(hit.transform.gameObject.name);
				}
                
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
