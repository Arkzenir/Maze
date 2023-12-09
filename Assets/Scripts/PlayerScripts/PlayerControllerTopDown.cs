using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerControllerTopDown : PlayerControllerBase
    {
        [SerializeField] protected float speed;
        public CharacterController CharacterController { get; private set; }
        private Vector3 _moveDirection;

        protected virtual void Start()
        {
            CharacterController = GetComponent<CharacterController>();
            _moveDirection = Vector3.zero;
            CanMove = true;
        }

        void Update()
        {
            Vector3 forward = Vector3.forward;
            Vector3 right = Vector3.right;
            float curSpeedX = CanMove ? speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = CanMove ? speed * Input.GetAxis("Horizontal") : 0;
            
            _moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            
            // Move the controller
            CharacterController.Move(_moveDirection * Time.deltaTime);
        }
    }
}