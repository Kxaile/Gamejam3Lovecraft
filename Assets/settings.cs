using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public float Volume;
    public float brightness;
    public float fov;
    [Header("Sliders")]
    public Slider VolSlider;
    public Slider BrightSlider;
    
    public struct Controls
    {
        Input left;
        Input left_alt;
        Input Right;
        Input Right_alt;
        Input Up;
        Input Up_alt;
        Input Down;
        Input Down_alt;
    }

    private void Start()
    {
        VolSlider.value = Volume;
        BrightSlider.value = brightness;
        
    }

    public void ChangedValue(float Value, int Indecator)
    {
        switch (Indecator)
        {
            case 0: VolSlider.value = Value;
                break;
            case 1: BrightSlider.value = Value;
                break;
        }
    }

}

