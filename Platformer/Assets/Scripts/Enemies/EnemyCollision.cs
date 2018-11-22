namespace Scripts.Enemies
{
    using UnityEngine;

    public class EnemyCollision : MonoBehaviour
    {
        private Animator _animator;

        private Rigidbody2D _rigidBody;

        private CapsuleCollider2D _capsuleCollider;

        private EnemyMovement _movement;

        public void OnDeathAnimationFinished()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody2D>();
            _capsuleCollider = GetComponent<CapsuleCollider2D>();
            _movement = GetComponent<EnemyMovement>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.relativeVelocity.y < 0.0f && collision.gameObject.CompareTag("Player"))
            {
                Destroy(_rigidBody);
                Destroy(_capsuleCollider);
                Destroy(_movement);

                _animator.SetBool("IsDead", true);
            }
        }
    }
}