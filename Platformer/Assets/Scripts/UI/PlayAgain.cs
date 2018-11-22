namespace Scripts.UI
{
    using UnityEngine;

    public class PlayAgain : MonoBehaviour
    {
        [SerializeField]
        private SceneChanger _sceneChanger;

        public void OnPlayAgainClicked()
        {
            _sceneChanger.FadeToPreviousScene();
        }
    }
}