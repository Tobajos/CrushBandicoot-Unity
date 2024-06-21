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

        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            
            Vector3 vector3 = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, targetObject.transform.position.z - 5);
            int playerHealth = playerInventory.OnHealthDecrese(1, vector3);
            targetObject.transform.position = vector3;
          

        }
    }
    // Update is called once per frame

}
