namespace Scripts.Runner
{
    using UnityEngine;

    public class MapGenerator : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _levels;

        private void Awake()
        {
            Instantiate(_levels[Random.Range(0, _levels.Length)]);
        }
    }
}