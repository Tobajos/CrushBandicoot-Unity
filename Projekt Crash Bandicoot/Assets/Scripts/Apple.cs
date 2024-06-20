using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            sounddManager.instance.PlayAppleSound();
            playerInventory.AppleCollected();
            gameObject.SetActive(false);
        }
    }
}