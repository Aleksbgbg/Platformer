namespace Scripts.Collectibles
{
    using UnityEngine;
    using UnityEngine.Events;

    public class CollectibleCollision : MonoBehaviour
    {
        public UnityEvent CollisionFinished;

        private Animator _gemAnimator;

        public void OnDestroyAnimationFinished()
        {
            CollisionFinished.Invoke();
            Destroy(gameObject);
        }

        private void Awake()
        {
            _gemAnimator = gameObject.GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _gemAnimator.SetBool("IsCollected", true);
            }
        }
    }
}