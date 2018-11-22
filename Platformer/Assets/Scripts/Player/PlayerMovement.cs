namespace Scripts.Player
{
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 40.0f;

        private float _horizontalMovement;

        private bool _crouch;

        private bool _jump;

        private Animator _playerAnimator;

        private PlayerController _playerController;

        public void OnLand()
        {
            _playerAnimator.SetBool("IsJumping", false);
        }

        public void OnCrouchChanged(bool isCrouching)
        {
            _playerAnimator.SetBool("IsCrouching", isCrouching);
        }

        private void Awake()
        {
            _playerAnimator = GetComponentInChildren<Animator>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            _horizontalMovement = Input.GetAxisRaw("Horizontal") * _speed;

            _playerAnimator.SetFloat("Speed", Mathf.Abs(_horizontalMovement));

            if (Input.GetButtonDown("Jump"))
            {
                _jump = true;
                _playerAnimator.SetBool("IsJumping", true);
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
            _playerController.Move(_horizontalMovement * Time.fixedDeltaTime, _crouch, _jump);
            _jump = false;
        }
    }
}