using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class sounddManager : MonoBehaviour
{
    public static sounddManager instance;

    public AudioSource appleSource;
    public AudioClip appleSound;
    public AudioClip boxDestroySound;
    public AudioClip jumpSound;
    public AudioClip teleportSound;
    private Slider volume;
    private float sliderValue;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("GlobalFloat", 0.5f);
        Debug.Log(sliderValue);
    }

    public void PlayAppleSound()
    {
        appleSource.volume = sliderValue;
        appleSource.PlayOneShot(appleSound);
        Debug.Log(appleSource.volume);
    }

    public void PlayBoxDestroySound()
    {
        appleSource.volume = sliderValue;
        appleSource.PlayOneShot(boxDestroySound);
    }

    public void PlayJumpSound()
    {
        appleSource.volume = sliderValue;
        appleSource.PlayOneShot(jumpSound);
    }

    public void PlayTeleportSound()
    {
        appleSource.volume = sliderValue;
        appleSource.PlayOneShot(teleportSound);
    }


}
