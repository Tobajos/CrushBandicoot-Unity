using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPlayer : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject targetObject;


    private void OnTriggerEnter(Collider other)
    {
        targetObject.transform.position = teleportTarget.transform.position;
        Debug.Log("teleport");
    }
}
