namespace Scripts.Player
{
    using Scripts.UI;

    using UnityEngine;

    public class PlayerDeathController : MonoBehaviour
    {
        [SerializeField]
        private SceneChanger _sceneChanger;

        private Animator _animator;

        private Collider2D[] _colliders;

        public void BeginDeath()
        {
            _animator.SetTrigger("IsDead");

            foreach (Collider2D playerCollider in _colliders)
            {
                Destroy(playerCollider);
            }
        }

        public void DieFast()
        {
            OnDeathFinished();
        }

        public void OnDeathFinished()
        {
            Destroy(gameObject.transform.parent.gameObject); // Shortcut for traversing the hierarchy via Transform(s)
            _sceneChanger.FadeToNextScene();
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _colliders = GetComponentsInParent<Collider2D>();
        }
    }
}