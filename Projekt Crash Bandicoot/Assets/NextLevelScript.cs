using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class NextLevelScript : MonoBehaviour
{
    public TextMeshProUGUI appleText;
    private PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {

        playerInventory = FindObjectOfType<PlayerInventory>();
        
    }

    void Update()
    {
        if (playerInventory != null)
        {
            UpdateDiamondText(playerInventory);
        }

    }
    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        appleText.text = playerInventory.NumberOfApples.ToString()+ "/50";
        if (playerInventory.NumberOfApples > PlayerPrefs.GetInt("NumberOfApplesLevel1"))
        {
            PlayerPrefs.SetInt("NumberOfApplesLevel1", playerInventory.NumberOfApples);
        }
            
        UnityEngine.Debug.Log(PlayerPrefs.GetInt("NumberOfApples1"));

    }


    public void buttonClicked()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void NextLevelButtonClicked()
    {
        SceneManager.LoadScene("level2");

    }
}