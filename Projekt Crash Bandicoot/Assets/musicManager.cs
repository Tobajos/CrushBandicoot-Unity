using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class musicManager : MonoBehaviour
{
    public static musicManager instance;
    public AudioSource musicSource;
    public AudioClip menuSound;
    public AudioClip jungleSound;
    public AudioClip desertSound;
    private float musicValue;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        musicValue = 1f;
    }

    public void PlayMenuSound()
    {
        musicSource.volume = musicValue;
        musicSource.PlayOneShot(menuSound);
        Debug.Log(musicSource.volume);
    }

    public void PlayJungleSound()
    {
        musicSource.volume = musicValue;
        musicSource.PlayOneShot(jungleSound);
    }

    public void PlayDesertSound()
    {
        musicSource.volume = musicValue;
        musicSource.PlayOneShot(desertSound);
    }
}
