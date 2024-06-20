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

        // Za�aduj now� scen� po zatrzymaniu
        SceneManager.LoadScene("level2");

        Debug.Log("nextLevel"); // Mo�esz tutaj dodatkowo doda� log, je�li potrzebujesz
    }
}
