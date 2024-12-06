using UnityEngine;

namespace aRPG
{
    public class Player : Character
    {
        [SerializeField] private PlayerInput playerInput;

        protected override void Awake()
        {
            base.Awake();
            playerInput = GetComponent<PlayerInput>();
        }
    }
}

