using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            soundManager.instance.PlayAppleSound();
            playerInventory.AppleCollected();
            gameObject.SetActive(false);
        }
    }
}