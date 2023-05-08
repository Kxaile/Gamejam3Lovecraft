using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class settings : MonoBehaviour
{
    public float MasterVolume;
    public float MusicVolume;
    public float SFXVolume;
    public float brightness;
    
    [Header("Sliders")]
    public Slider MasterVolSlider;
    public Slider MusicVolSlider;
    public Slider SFXSlider;
    public Slider BrightSlider;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("settings");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void updateRTCPValues()
    {
        MasterVolume = MasterVolSlider.value;
        MusicVolume = MusicVolSlider.value;
        SFXVolume = SFXSlider.value;
        brightness = BrightSlider.value;

        AkSoundEngine.SetRTPCValue("MasterVolume", MasterVolume);
        AkSoundEngine.SetRTPCValue("MusicVolume", MusicVolume);
        AkSoundEngine.SetRTPCValue("SFXVolume", SFXVolume);
    }

    private void Start()
    {
        //read from player prefs
        // set XSlider.value = pref X value

        

        updateRTCPValues();

        
    }
   

}

