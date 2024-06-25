using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public AudioSource soundsSource;
    public AudioSource musicSource;
    private float sliderValue;
    private float musicValue;
    public Slider slider;
    public Slider musicSlider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("GlobalFloat", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicFloat", 1f);

    }


    public void SaveSliderValue()
    {
        sliderValue = slider.value;
        soundsSource.volume = sliderValue;
        PlayerPrefs.SetFloat("GlobalFloat", sliderValue);
        PlayerPrefs.Save();
    }

    public void SaveMusicValue()
    {
        musicValue = musicSlider.value;
        musicSource.volume = musicValue;
        PlayerPrefs.SetFloat("MusicFloat", musicValue);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("MusicFloat")+"getfloat");

    }

}
