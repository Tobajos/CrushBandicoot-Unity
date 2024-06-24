using UnityEngine;

public class FasterFall : MonoBehaviour
{
    public float gravityMultiplier = 2.0f;
    public float additionalDownwardForce = 30.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Increase gravity effect
        rb.useGravity = true;
        

        // Ensure drag is zero for no resistance
        rb.drag = 0;
        rb.angularDrag = 0;
    }

    void Update()
    {
        // Apply additional downward force
        rb.AddForce(Vector3.down * additionalDownwardForce, ForceMode.Acceleration);
    }
}