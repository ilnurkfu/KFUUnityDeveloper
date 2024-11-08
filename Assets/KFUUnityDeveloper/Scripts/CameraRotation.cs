using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float Sensivity;
    [SerializeField] private float minVertialAngle;
    [SerializeField] private float maxVertialAngle;
    [SerializeField] private float xRotation;

    [SerializeField] private Transform playerTransfrom;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Sensivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Sensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minVertialAngle, maxVertialAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransfrom.Rotate(Vector3.up, mouseX);
    }
}
