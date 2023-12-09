using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerControllerFPS : PlayerControllerBase
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpSpeed;
        [SerializeField] private float gravity;
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float lookSpeed;
        [SerializeField] private float lookXLimit;

        public CharacterController CharacterController { get; private set; }
        private Vector3 _moveDirection;
        private Vector2 _rotation;
    
        //Properties to access movement variables
        public Vector3 MoveDirection
        {
            get => _moveDirection;
            private set => _moveDirection = value;
        }
        
        void Start()
        {
            CharacterController = GetComponent<CharacterController>();
            _moveDirection = Vector3.zero;
            _rotation = Vector2.zero;
            CanMove = true;
            _rotation.y = transform.eulerAngles.y;
        }

        void Update()
        {
            if (CharacterController.isGrounded)
            {
                // We are grounded, so recalculate move direction based on axes
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                float curSpeedX = CanMove ? speed * Input.GetAxis("Vertical") : 0;
                float curSpeedY = CanMove ? speed * Input.GetAxis("Horizontal") : 0;
                _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

                if (Input.GetButton("Jump") && CanMove)
                {
                    _moveDirection.y = jumpSpeed;
                }
            }

            // Apply gravity. Gravity is multiplied by deltaTime twice
            //This is because gravity should be applied as an acceleration (ms^-2)
            _moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            CharacterController.Move(_moveDirection * Time.deltaTime);

            // Player and Camera rotation
            if (CanMove)
            {
                _rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
                _rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
                _rotation.x = Mathf.Clamp(_rotation.x, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(_rotation.x, 0, 0);
                transform.eulerAngles = new Vector2(0, _rotation.y);
            }
        }
    }
}