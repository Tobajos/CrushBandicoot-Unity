using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFlyThrough : MonoBehaviour
{
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    public string mouseXAxis = "Mouse X";
    public string mouseYAxis = "Mouse Y";

    public float lookSpeed = 50f;
    public float moveSpeed = 15f;

    private Vector2 rotationInput = Vector2.zero;
    private Vector3 speedInput = Vector3.zero;

    private void LateUpdate()
    {
        rotationInput = new Vector2(Input.GetAxis(mouseXAxis), Input.GetAxis(mouseYAxis)) * lookSpeed * Time.deltaTime;
        rotationInput.y = Mathf.Clamp(rotationInput.y, -90, 90);

        float height = 0f;
        if (Input.GetKey(KeyCode.Q)) height = -1f;
        else if (Input.GetKey(KeyCode.E)) height = 1f;

        speedInput = new Vector3(Input.GetAxis(verticalAxis), height, Input.GetAxis(horizontalAxis)) * moveSpeed * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;
        rotation += rotationInput.x * Vector3.up + rotationInput.y * Vector3.left;
        rotation.z = 0f;
        transform.localEulerAngles = rotation;

        transform.position += transform.forward * speedInput.x +
            transform.up * speedInput.y + 
            transform.right * speedInput.z;
    }
}
