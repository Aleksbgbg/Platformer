namespace Scripts.Player
{
    using UnityEngine;

    public class PlayerCameraCoordinator : MonoBehaviour
    {
        private PlayerDeathController _playerDeathController;

        private void Awake()
        {
            _playerDeathController = GetComponent<PlayerDeathController>();
        }

        private void OnBecameInvisible()
        {
            _playerDeathController.DieFast();
        }
    }
}