namespace Scripts.UI
{
    using System.Collections;

    using UnityEngine;
    using UnityEngine.UI;

    public class ScoreScript : MonoBehaviour
    {
        [SerializeField]
        private float _smoothTime = 0.3f;

        [SerializeField]
        private Text _subScore;

        private bool _isMoving;

        private int _scoreValue;

        private Vector3 _velocity;

        private Transform _subScoreTransform;

        private Transform _scoreTransform;

        private Text _score;

        public void OnCollectiblePickedUp()
        {
            IncreaseScore(10);
        }

        private void MoveSubScore()
        {
            _subScoreTransform.position = Vector3.SmoothDamp(_subScoreTransform.position, _scoreTransform.position, ref _velocity, _smoothTime);
        }

        private IEnumerator HideSubScore()
        {
            yield return new WaitForSeconds(1.0f);

            _subScore.text = string.Empty;
            _isMoving = false;
            _subScoreTransform.position = new Vector3(_subScoreTransform.position.x, 93.2f, 0f);
        }

        private void IncreaseScore(int increase)
        {
            _isMoving = true;
            _subScore.text = string.Concat("+", increase);

            StartCoroutine(HideSubScore());

            _scoreValue += increase;
            _score.text = _scoreValue.ToString();
        }

        private void Awake()
        {
            _score = GetComponent<Text>();
            _scoreTransform = GetComponent<Transform>();
            _subScoreTransform = _subScore.GetComponent<Transform>();
        }

        private void Update()
        {
            if (_isMoving)
            {
                MoveSubScore();
            }
        }
    }
}