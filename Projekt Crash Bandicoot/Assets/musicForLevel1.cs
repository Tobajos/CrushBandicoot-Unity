using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicForLevel1 : MonoBehaviour
{
    private float musicVolume;
    private float soundsVolume;

    public AudioSource soundSource;
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicFloat",0.5f);
        musicSource.volume = musicVolume;
        Debug.Log(musicSource);
        //musicManager.instance.PlayJungleSound();
        Debug.Log(musicSource.volume);
        soundsVolume = PlayerPrefs.GetFloat("GlobalFloat");
        soundSource.volume = soundsVolume;
        Debug.Log(soundSource.volume);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
