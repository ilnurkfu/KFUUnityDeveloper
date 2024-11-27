using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float distance;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private float height;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float currentX;
    [SerializeField] private float currentY;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private Transform player;

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY, minY, maxY);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        Vector3 targetPosition = player.position;
        Vector3 offset = rotation * new Vector3(0f, height, -distance);

        Vector3 desiredPosition = targetPosition + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.LookAt(targetPosition);
    }
}
