using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.XR;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfApples { get; private set; }
    public UIController uiController;
    public int Health { get; set; } = 3;
    public PlayerMovement player;
    public GameObject teleportTarget;
    public InventoryUI inventoryUI;

    // public UnityEvent<PlayerInventory> OnHealthDecrese;
    //public UnityEvent<PlayerInventory> OnDiamondCollected;

    void Start()
    {
        Time.timeScale = 1;
        player = GetComponent<PlayerMovement>();
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SkeletonWeapon"))
        {
            
            Vector3 knockbackDirection = (transform.position - other.transform.position).normalized;

            int playerHealth = OnHealthDecrese(1, knockbackDirection);

            if (playerHealth <= 0)
            {
                inventoryUI.ShowGameOverPanel();
                Time.timeScale = 0;
            }
        }
        
    }

    public void AppleCollected()
    {
        NumberOfApples++;
        //OnDiamondCollected.Invoke(this);
    }

    public int OnHealthDecrese(int damage,Vector3 direction)
    {
        player.Knockback(direction);
        Health -= damage;
        Debug.Log("minus");
        return Health;
    }


}