using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPlayerWater : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject targetObject;
    private PlayerInventory player;
    private InventoryUI inventoryUI;
    

    void Start()
    {
        Time.timeScale = 1;
        player = FindObjectOfType<PlayerInventory>();
        inventoryUI = FindObjectOfType<InventoryUI>();
    }


    private void OnTriggerEnter(Collider other)
    {
        targetObject.transform.position = teleportTarget.transform.position;
        int health = player.OnHealthDecrese(1, new Vector3(0, 0, 0));

        if (health <= 0)
        {
            inventoryUI.ShowGameOverPanel();
            Time.timeScale = 0;
        }
    }
}