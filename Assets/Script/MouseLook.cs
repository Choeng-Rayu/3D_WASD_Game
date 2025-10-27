using UnityEngine;

// Simple mouse look. Attach to Camera (child of CameraHolder).
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody; // assign the Player's transform

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // yaw - rotate player body
        if (playerBody != null)
            playerBody.Rotate(Vector3.up * mouseX);

        // pitch - rotate camera only
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
