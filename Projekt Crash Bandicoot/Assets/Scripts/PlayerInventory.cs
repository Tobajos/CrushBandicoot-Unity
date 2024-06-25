using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.XR;
using System.Diagnostics;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfApples { get; private set; }
    public int Health { get; set; } = 3;
    public PlayerMovement player;
    private InventoryUI inventoryUI;

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
        soundManager.instance.PlayCrashSound();

        return Health;

    }


}