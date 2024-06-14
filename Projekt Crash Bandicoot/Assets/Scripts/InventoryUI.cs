using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI appleText;
    public TextMeshProUGUI healthText;
    PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();

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
}