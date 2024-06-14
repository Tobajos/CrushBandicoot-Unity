using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecrese : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportTarget;
    public GameObject targetObject;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WCHODZI RAZ");
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            int playerHealth = playerInventory.OnHealthDecrese();
            Vector3 vector3 = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, targetObject.transform.position.z - 5);
            targetObject.transform.position = vector3;
            Debug.Log(playerHealth);
            if (playerHealth == 0)
            {
                targetObject.transform.position = teleportTarget.transform.position;
            }

        }
    }
    // Update is called once per frame

}
