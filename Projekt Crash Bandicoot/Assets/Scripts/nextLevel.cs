using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        sounddManager.instance.PlayTeleportSound();
        StartCoroutine(LoadNextLevelAfterDelay());
    }

    IEnumerator LoadNextLevelAfterDelay()
    {
        // Zatrzymaj wykonanie na 3 sekundy
        yield return new WaitForSeconds(3f);

        // Za³aduj now¹ scenê po zatrzymaniu
        SceneManager.LoadScene("level2");

        Debug.Log("nextLevel"); // Mo¿esz tutaj dodatkowo dodaæ log, jeœli potrzebujesz
    }
}
