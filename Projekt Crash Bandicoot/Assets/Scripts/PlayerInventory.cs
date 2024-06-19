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
    // public UnityEvent<PlayerInventory> OnHealthDecrese;
    //public UnityEvent<PlayerInventory> OnDiamondCollected;

    void Start()
    {
        player = GetComponent<PlayerMovement>();

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