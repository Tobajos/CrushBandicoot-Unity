using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{

    public GameObject[] canvases;
    public AudioSource soundSource;
    public AudioSource musicSource;
    private float soundVolume;
    private float musicVolume;




    public void StartButtonPressed()
    {
        ShowCanvas(2);
    }

    public void BackButtonPressed()
    {
        ShowCanvas(0);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();

    }



    public void SettingsButtonPressed()
    {
        UnityEngine.Debug.Log("settings");
        ShowCanvas(1);

    }
    // Start is called before the first frame update
    void Start()
    {
        ShowCanvas(0);
        UnityEngine.Debug.Log(soundVolume);
        UnityEngine.Debug.Log(musicVolume);
        soundVolume = PlayerPrefs.GetFloat("GlobalFloat", 1f);
        musicVolume = PlayerPrefs.GetFloat("MusicFloat", 1f);
        soundSource.volume = soundVolume;
        musicSource.volume = musicVolume;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCanvas(int index) {
        for (int i = 0; i < canvases.Length; i++)
        { 
            canvases[i].SetActive(i == index);
        }
    }

    public void level1Pressed()
    {
        SceneManager.LoadScene("level1");
    }

    public void level2Pressed()
    {
        SceneManager.LoadScene("level2");
    }




}
