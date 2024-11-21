using UnityEngine;

namespace FPSController
{
    public class CollisionObject : MonoBehaviour, ICollisionObject
    {
        [SerializeField] private float buffSpeed;

        public float BuffSpeed
        {
            get
            {
                return buffSpeed;
            }
        }
    }
}