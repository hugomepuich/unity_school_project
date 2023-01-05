using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    public Transform camera;
    public float mouseSensitivity = 5000.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * 5 * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * 5 * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(0, rotY, 0.0f);
        transform.rotation = localRotation;
        camera.transform.rotation = Quaternion.Euler(rotX, rotY, 0.0f);
    }
}