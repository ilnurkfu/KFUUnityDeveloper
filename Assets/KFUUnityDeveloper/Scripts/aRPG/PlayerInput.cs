using UnityEngine;
using UnityEngine.AI;

namespace aRPG
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private float distance;

        [SerializeField] private LayerMask layer;

        [SerializeField] private PlayerMovement playerMovement;

        [SerializeField] private NavMeshAgent agent;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out RaycastHit hit, distance, layer))
                {
                    if (hit.transform.GetComponent<IClickableObject>() != null)
                    {
                        //playerMovement.MoveTowardsTarget(hit.point);
                        hit.transform.GetComponent<IClickableObject>().Click();
                        agent.SetDestination(hit.point);
                    }
                }
            }
        }
    }
}

