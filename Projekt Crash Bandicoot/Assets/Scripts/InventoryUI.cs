using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI appleText;

    // Start is called before the first frame update
    void Start()
    {
        appleText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        appleText.text = playerInventory.NumberOfApples.ToString();
    }
}