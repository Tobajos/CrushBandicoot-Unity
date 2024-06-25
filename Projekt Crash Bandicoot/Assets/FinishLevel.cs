using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject[] canvases;


    void Start()
    {
        ShowCanvas(0);
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

        // Za³aduj now¹ scenê po zatrzymaniu
        //SceneManager.LoadScene("level2");
        ShowCanvas(1);
       
    }
}
