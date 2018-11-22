namespace Scripts.Runner
{
    using System.Collections.Generic;

    using UnityEngine;

    public class MapGenerator : MonoBehaviour
    {
        private readonly Queue<Level> _levelQueue = new Queue<Level>();

        [SerializeField]
        private Camera _mainCamera;

        [SerializeField]
        private Transform[] _levels;

        private float _spawnPosition;

        private Level _activeLevel;

        private void ActivateLevel()
        {
            ActivateLevel(Random.Range(0, _levels.Length));
        }

        private void ActivateLevel(int index)
        {
            Transform activeLevelTransform = Instantiate(_levels[index], new Vector3(_spawnPosition, 0.0f, 0.0f), new Quaternion());

            Level activeLevel = new Level(activeLevelTransform);

            _levelQueue.Enqueue(activeLevel);
            _activeLevel = activeLevel;

            _spawnPosition += activeLevel.Size;
        }

        private void Awake()
        {
            ActivateLevel(1);
        }

        private void Update()
        {
            if (_levelQueue.Count > 1 &&
                !_levelQueue.Peek().IsVisible)
            {
                _levelQueue.Dequeue().Destroy();
            }

            if (_activeLevel.IsNearingEnd(_mainCamera))
            {
                ActivateLevel();
            }
        }
    }
}