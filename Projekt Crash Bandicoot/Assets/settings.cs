using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{

    private float sliderValue;
    public Slider slider;

    public void SaveSliderValue()
    {
        sliderValue = slider.value;
        PlayerPrefs.SetFloat("GlobalFloat", sliderValue);
        PlayerPrefs.Save();
        Debug.Log(sliderValue);
    }

    public float GetSliderValue()
    {
        return sliderValue;
        
    }
}
