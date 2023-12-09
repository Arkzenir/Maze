using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerControllerTopDown : MonoBehaviour
    {
        [SerializeField] protected float speed;
        protected CharacterController CharacterController { get; private set; }
        protected Vector3 MoveDirection;
    
        protected bool CanMove;

        protected virtual void Start()
        {
            CharacterController = GetComponent<CharacterController>();
            MoveDirection = Vector3.zero;
            CanMove = true;
        }

        void Update()
        {
            Vector3 forward = Vector3.forward;
            Vector3 right = Vector3.right;
            float curSpeedX = CanMove ? speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = CanMove ? speed * Input.GetAxis("Horizontal") : 0;
            
            MoveDirection = (forward * curSpeedX) + (right * curSpeedY);
            
            // Move the controller
            CharacterController.Move(MoveDirection * Time.deltaTime);
        }
    }
}