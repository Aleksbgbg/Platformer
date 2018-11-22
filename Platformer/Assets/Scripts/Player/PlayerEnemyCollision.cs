namespace Scripts.Player
{
    using UnityEngine;

    public class PlayerEnemyCollision : MonoBehaviour
    {
        private PlayerController _playerController;

        private PlayerDeathController _playerDeathController;

        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            _playerDeathController = GetComponentInChildren<PlayerDeathController>();
            _rigidBody = GetComponent<Rigidbody2D>();
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
                    _playerDeathController.BeginDeath();
                }
            }
        }
    }
}