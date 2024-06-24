using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    public AudioSource soundSource;
    public AudioClip appleSound;
    public AudioClip boxDestroySound;
    public AudioClip jumpSound;
    public AudioClip teleportSound;
    public AudioClip crashSound;
    private float sliderValue;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("GlobalFloat");
        
    }

    public void PlayAppleSound()
    {
        soundSource.volume = sliderValue;
        soundSource.PlayOneShot(appleSound);
        Debug.Log(soundSource.volume);
    }

    public void PlayBoxDestroySound()
    {
        soundSource.volume = sliderValue;
        soundSource.PlayOneShot(boxDestroySound);
    }

    public void PlayJumpSound()
    {
        soundSource.volume = sliderValue;
        soundSource.PlayOneShot(jumpSound);
    }

    public void PlayTeleportSound()
    {
        soundSource.volume = sliderValue;
        soundSource.PlayOneShot(teleportSound);
    }

    public void PlayCrashSound()
    {
        soundSource.volume = sliderValue;
        soundSource.PlayOneShot(crashSound);
    }

}
