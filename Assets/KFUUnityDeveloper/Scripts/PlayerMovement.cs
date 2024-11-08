using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isGrounded;

    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float raycastDistance;
    [SerializeField] private float radius;

    [SerializeField] private LayerMask targetLayer;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private Rigidbody rigi;

    private void Awake()
    {
        if(GetComponent<Rigidbody>() != null)
        {
            rigi = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        if(isGroundedWithSphere())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if(isGrounded == true)
        {
            PhysicsMove();
        }
    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Debug.Log(Horizontal);

        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        transform.position += direction * speed * Time.deltaTime;


    }

    private void PhysicsMove()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = (Horizontal * transform.right + Vertical * transform.forward).normalized * speed * Time.fixedDeltaTime;
        Vector3 newLinearVelocity = new Vector3(direction.x, rigi.linearVelocity.y, direction.z);
        rigi.linearVelocity = newLinearVelocity;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigi.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private bool isGroundWithRaycast()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, raycastDistance, targetLayer);
        return isGrounded;
    }

    private bool isGroundedWithSphere()
    {
        isGrounded = Physics.OverlapSphere(groundCheck.position, radius, targetLayer).Length > 0;
        return isGrounded;
    }

    private bool isGroundedWithPhysics()
    {
        isGrounded = -0.00001f < rigi.linearVelocity.y && rigi.linearVelocity.y < 0.0001f;
        return isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(groundCheck.position, radius);

            //Gizmos.color = Color.blue;
            //Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * raycastDistance);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("TriggerStay");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CollisionEnter");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("CollisionExit");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("CollisionStay");
    }
}
