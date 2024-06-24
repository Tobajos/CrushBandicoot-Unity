using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPlayer : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject targetObject;
    private PlayerInventory player;

    private void Start()
    {
        player = GetComponent<PlayerInventory>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Sphere"))
            {
                targetObject.transform.position = teleportTarget.transform.position;
                //player.OnHealthDecrese(1,new Vector3(0,0,0));
            }
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Sphere"))
            {

                Debug.Log("kolizja");
                player.OnHealthDecrese(1, new Vector3(0, 0, 0));
            }
        }
    }
}
