﻿namespace Scripts.Player
{
    using System.Linq;

    using Scripts.Attributes;
    using Scripts.Events;

    using UnityEngine;
    using UnityEngine.Events;

    public class PlayerController : MonoBehaviour
    {
        private const float CeilingOverlapRadius = 0.2f;

        private const float GroundOverlapRadius = 0.2f;

        [Header("Events")]
        [Space]
        public UnityEvent OnLandEvent;

        public BoolEvent OnCrouchEvent;

        [SerializeAs("Jump Force")]
        [SerializeField]
        private float _jumpForce = 400.0f;

        [Range(0.0f, 1.0f)]
        [SerializeAs("Speed Fraction When Crouched")]
        [SerializeField]
        private float _speedFractionWhenCrouched = 0.8f;

        [Range(0, 0.3f)]
        [SerializeAs("Movement Smoothing")]
        [SerializeField]
        private float _movementSmoothing = 0.05f;

        [SerializeAs("Can Steer While Airborne")]
        [SerializeField]
        private bool _canSteerWhileAirborne;

        [SerializeAs("Ground Layer Mask")]
        [SerializeField]
        private LayerMask _groundLayerMask;

        [SerializeAs("Player Head")]
        [SerializeField]
        private Transform _playerHead; // A position marking where to check for ceilings

        [SerializeAs("Player Feet")]
        [SerializeField]
        private Transform _playerFeet; // A position marking where to check for ground

        [SerializeAs("Collider to Disable on Crouch")]
        [SerializeField]
        private Collider2D _colliderToDisableOnCrouch;

        private bool _grounded;

        private bool _wasCrouching;

        private bool _facingRight = true;

        private Rigidbody2D _rigidbody;

        private Vector3 _velocity = Vector3.zero;

        public void Move(float movement, bool crouch, bool jump)
        {
            if (!crouch)
            {
                if (Physics2D.OverlapCircle(_playerHead.position, CeilingOverlapRadius, _groundLayerMask))
                {
                    // Can't stand up due to obstacle on head, even though the player has stopped crouching
                    crouch = true;
                }
            }

            if (_grounded || _canSteerWhileAirborne)
            {
                if (crouch)
                {
                    if (_colliderToDisableOnCrouch != null)
                    {
                        _colliderToDisableOnCrouch.enabled = false;
                    }

                    if (!_wasCrouching)
                    {
                        _wasCrouching = true;
                        OnCrouchEvent?.Invoke(true);
                    }

                    movement *= _speedFractionWhenCrouched;
                }
                else
                {
                    if (_colliderToDisableOnCrouch != null)
                    {
                        _colliderToDisableOnCrouch.enabled = true;
                    }

                    if (_wasCrouching)
                    {
                        _wasCrouching = false;
                        OnCrouchEvent?.Invoke(false);
                    }
                }

                Vector3 targetVelocity = new Vector2(movement * 10.0f, _rigidbody.velocity.y);
                
                _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _velocity, _movementSmoothing);

                if ((movement > 0 && !_facingRight) || (movement < 0 && _facingRight))
                {
                    Flip();
                }
            }

            if (_grounded && jump)
            {
                _grounded = false;
                _rigidbody.AddForce(new Vector2(0.0f, _jumpForce));
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            bool wasGrounded = _grounded;

            _grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerFeet.position, GroundOverlapRadius, _groundLayerMask);

            if (colliders.Any(collider => collider.gameObject != gameObject))
            {
                _grounded = true;

                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }

        private void Flip()
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
            _facingRight = !_facingRight;
        }
    }
}