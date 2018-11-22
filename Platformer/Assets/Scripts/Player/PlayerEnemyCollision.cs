namespace Scripts.Player
{
    using UnityEngine;

    public class PlayerEnemyCollision : MonoBehaviour
    {
        private Animator _animator;

        private PlayerController _playerController;

        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerController = gameObject.GetComponent<PlayerController>();
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (collision.relativeVelocity.y > 0.0f)
                {
                    _rigidBody.AddForce(new Vector2(0.0f, _playerController.JumpForce));
                }
                else
                {
                    _animator.SetTrigger("IsDead");
                }
            }
        }
    }
}