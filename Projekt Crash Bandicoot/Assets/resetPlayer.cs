using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPlayer : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject targetObject;
    private PlayerInventory player;
    private bool flaga;
    private InventoryUI inventoryUI;

    private void Start()
    {
        flaga = false;
        Time.timeScale = 1;
        player = GetComponent<PlayerInventory>();
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!flaga && collision != null && collision.gameObject.CompareTag("Sphere"))
        {
            flaga = true;

            // Przeniesienie obiektu na pozycjê teleportTarget
            targetObject.transform.position = teleportTarget.transform.position;

            // Zmniejszenie zdrowia gracza
            int health = player.OnHealthDecrese(1, new Vector3(0, 0, 0));

            if (health <= 0)
            {
                inventoryUI.ShowGameOverPanel();
                Time.timeScale = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Sphere"))
        {
            flaga = false;
        }
    }


}
