using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AK.Wwise.Editor;
using AK.Wwise;

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
