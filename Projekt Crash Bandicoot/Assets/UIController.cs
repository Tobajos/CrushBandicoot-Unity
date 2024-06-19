using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{


    public void StartButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButtonPressed()
    {
        Application.Quit();

    }

    public void SettingsButtonPressed()
    {
        UnityEngine.Debug.Log("settings");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   

}
