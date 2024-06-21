using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI appleText;
    public TextMeshProUGUI healthText;
    PlayerInventory playerInventory;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

        playerInventory = FindObjectOfType<PlayerInventory>();
        panel.SetActive(false);
    }

    void Update()
    {
        if (playerInventory != null)
        {
            UpdateHealthText(playerInventory);
            UpdateDiamondText(playerInventory);
        }

    }
    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        appleText.text = playerInventory.NumberOfApples.ToString();
    }

    public void UpdateHealthText(PlayerInventory playerInventory)
    {
        healthText.text = playerInventory.Health.ToString();
    }

    public void ShowGameOverPanel()
    {
    
        Debug.Log("asd");
        panel.SetActive(true);

    }

    public void buttonClicked() {
        Debug.Log("essa");
       
        SceneManager.LoadScene("MainMenu");
    }
}