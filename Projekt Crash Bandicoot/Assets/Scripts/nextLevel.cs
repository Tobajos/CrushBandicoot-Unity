using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public GameObject[] canvases;


    void Start()
    {
        ShowCanvas(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        soundManager.instance.PlayTeleportSound();
        StartCoroutine(LoadNextLevelAfterDelay());
    }

    public void ShowCanvas(int index)
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(i == index);
        }
    }

    IEnumerator LoadNextLevelAfterDelay()
    {
        // Zatrzymaj wykonanie na 3 sekundy
        yield return new WaitForSeconds(3f);

        // Za�aduj now� scen� po zatrzymaniu
        //SceneManager.LoadScene("level2");
        ShowCanvas(0);
        Debug.Log("nextLevel"); // Mo�esz tutaj dodatkowo doda� log, je�li potrzebujesz
    }
}
