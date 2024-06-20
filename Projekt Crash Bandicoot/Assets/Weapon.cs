using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other is CapsuleCollider)
        {
            UnityEngine.Debug.Log("qwe");
        }

        if (other is BoxCollider)
        {
            UnityEngine.Debug.Log("asd");
        }

    }

    // Update is called once per frame
    void Update()
    {
        var redn= GetComponent<SkinnedMeshRenderer>();
        var box = GetComponent<BoxCollider>();
        box.transform.position = redn.transform.position;
    }
}
