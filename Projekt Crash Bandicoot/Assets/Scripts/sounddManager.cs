using UnityEngine;

public class sounddManager : MonoBehaviour
{
    public static sounddManager instance;

    public AudioSource appleSource;
    public AudioClip appleSound;
    public AudioClip boxDestroySound;
    public AudioClip jumpSound;
    public AudioClip teleportSound;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        appleSource = GetComponent<AudioSource>();
    }

    public void PlayAppleSound()
    {
        appleSource.volume = 0.5f;
        appleSource.PlayOneShot(appleSound);
    }

    public void PlayBoxDestroySound()
    {
        appleSource.volume = 0.1f;
        appleSource.PlayOneShot(boxDestroySound);
    }

    public void PlayJumpSound()
    {
        appleSource.volume = 0.1f;
        appleSource.PlayOneShot(jumpSound);
    }

    public void PlayTeleportSound()
    {
        appleSource.volume = 0.1f;
        appleSource.PlayOneShot(teleportSound);
    }


}
