using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float speed = 5f; // Speed of the pusher
    public float maxDistance = 10f; // Maximum distance to move before changing direction

    private bool movingForward = true; // Flag indicating the direction of movement
    private float traveledDistance = 0f; // Distance traveled by the pusher
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (movingForward)
        {
            Move(speed);
        }
        else
        {
            Move(-speed);
        }

        // Check if the pusher has reached the max distance
        if (traveledDistance >= maxDistance)
        {
            movingForward = !movingForward; // Change direction
            traveledDistance = 0f; // Reset the traveled distance
        }
    }

    void Move(float speed)
    {
        Vector3 movement = transform.right * speed * Time.deltaTime;
        transform.Translate(movement);

        // Update the traveled distance
        traveledDistance += movement.magnitude;
    }
}
