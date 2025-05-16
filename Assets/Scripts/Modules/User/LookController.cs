using UnityEngine;

public class LookController : MonoBehaviour
{
    public float Sensitivity = 2f;
    public Transform PlayerBody;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * xRotation;

        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
