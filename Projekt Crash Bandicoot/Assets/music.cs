using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private float musicVolume;
    private float soundsVolume;

    public AudioSource soundSource;
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicFloat", 0.5f);
        musicSource.volume = musicVolume;

        soundsVolume = PlayerPrefs.GetFloat("GlobalFloat");
        soundSource.volume = soundsVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
