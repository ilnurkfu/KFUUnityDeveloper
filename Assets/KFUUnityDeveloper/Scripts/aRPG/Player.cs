using UnityEngine;
using UnityEngineInternal;

namespace aRPG
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.GetComponent<IClickableObject>() != null)
                    {
                        playerMovement.MoveTowardsTarget(hit.point);
                    }
                }
            }
        }
    }
}

