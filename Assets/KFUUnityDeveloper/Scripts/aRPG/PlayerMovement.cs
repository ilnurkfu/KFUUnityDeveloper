using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace aRPG
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private bool isMoving;

        [SerializeField] private NavMeshAgent agent;
        
        [SerializeField] private float requiredDistance;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float offsetY;

        [SerializeField] private Vector3 targetPosition;

        private void Update()
        {
            if (isMoving)
            {
                Vector3 direction = (targetPosition - transform.position).normalized;

                Quaternion targetRotiton = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotiton, rotationSpeed * Time.deltaTime);

                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                if ((targetPosition - transform.position).sqrMagnitude < requiredDistance * requiredDistance)
                {
                    isMoving = false;
                }
            }
        }

        public void MoveTowardsTarget(Vector3 newTargetPosition)
        {
            newTargetPosition += Vector3.up * offsetY;
            targetPosition = newTargetPosition;
            isMoving = true;
        }
    }
}