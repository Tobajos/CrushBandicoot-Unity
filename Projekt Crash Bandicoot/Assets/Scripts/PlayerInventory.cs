using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfApples { get; private set; }

    public int Health { get; set; } = 3;
    public PlayerMovement player;
    public GameObject teleportTarget;
    // public UnityEvent<PlayerInventory> OnHealthDecrese;
    //public UnityEvent<PlayerInventory> OnDiamondCollected;

    void Start()
    {
        player = GetComponent<PlayerMovement>();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SkeletonWeapon"))
        {

            Vector3 knockbackDirection = (transform.position - other.transform.position).normalized;

            int playerHealth = OnHealthDecrese(1, knockbackDirection);

            if (playerHealth == 0)
            {
                transform.position = teleportTarget.transform.position;
                Health = 3;
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
        
        return Health;
    }
}