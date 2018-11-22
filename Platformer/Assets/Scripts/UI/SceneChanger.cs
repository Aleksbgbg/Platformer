namespace Scripts.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneChanger : MonoBehaviour
    {
        private int _loadSceneIndex;

        private Animator _animator;

        public void FadeToScene(int sceneIndex)
        {
            _loadSceneIndex = sceneIndex;
            _animator.SetTrigger("FadeOut");
        }

        public void FadeToPreviousScene()
        {
            FadeToRelativeScene(-1);
        }

        public void FadeToNextScene()
        {
            FadeToRelativeScene(1);
        }

        public void OnFadeComplete()
        {
            SceneManager.LoadScene(_loadSceneIndex);
        }

        private void FadeToRelativeScene(int relativeIndex)
        {
            FadeToScene(SceneManager.GetActiveScene().buildIndex + relativeIndex);
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}