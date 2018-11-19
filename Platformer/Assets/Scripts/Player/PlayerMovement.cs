namespace Scripts.Player
{
    using UnityEngine;
    using Cinemachine;

    public class PlayerMovement : MonoBehaviour
    {
        public PlayerController PlayerController;

        public Animator PlayerAnimator;

        public Transform Camera;

        public float Speed = 60.0f;

        public float CameraSpeed = 20.0f;

        private float _horizontalMovement;

        private bool _jump;

        private bool _crouch;

        public void OnLand()
        {
            PlayerAnimator.SetBool("IsJumping", false);
        }

        public void OnCrouchChanged(bool isCrouching)
        {
            PlayerAnimator.SetBool("IsCrouching", isCrouching);
        }

        private void Start()
        {
            Camera.transform.position = transform.position - new Vector3(0, 0, 10);
        }

        private void OnBecameInvisible()
        {
            // ded
        }

        private void Update()
        {
            //_horizontalMovement = Input.GetAxisRaw("Horizontal") * Speed;
            _horizontalMovement = Speed;

            Vector3 velocity = new Vector3(1, 0, 0);

            Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position, Camera.transform.position + new Vector3(2.5f, 0f, 0f), ref velocity, 0.1f);

            if (transform.position.x - Camera.transform.position.x > 0)
            {
                Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position, new Vector3(transform.position.x, Camera.transform.position.y, Camera.transform.position.z), ref velocity, 0.1f);

            }

            PlayerAnimator.SetFloat("Speed", Mathf.Abs(_horizontalMovement));

            if (Input.GetButtonDown("Jump"))
            {
                _jump = true;
                PlayerAnimator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                _crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                _crouch = false;
            }
        }

        private void FixedUpdate()
        {
            PlayerController.Move(_horizontalMovement * Time.fixedDeltaTime, _crouch, _jump);
            _jump = false;
        }
    }
}