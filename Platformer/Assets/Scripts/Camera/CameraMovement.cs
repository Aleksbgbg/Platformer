namespace Scripts.Camera
{
    using UnityEngine;

    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5.0f;

        [SerializeField]
        private Transform _player;

        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float _deadZoneWidth;

        private void Update()
        {
            Vector3 cameraPosition = gameObject.transform.position;
            cameraPosition.x += _speed * Time.deltaTime;

            if (_player.position.x > cameraPosition.x)
            {
                cameraPosition.x = _player.position.x;
            }

            if (_player.position.y > 0)
            {
                float diff = _player.position.y - cameraPosition.y;

                if (Mathf.Abs(diff) > _deadZoneWidth)
                {
                    //cameraPosition.y = _player.position.y;
                    cameraPosition.y += diff;
                }

                //float distance = cameraPosition.y - _player.position.y * (_camera.pixelHeight / (float)_ppu);

                //Debug.Log(distance);

                //if (Mathf.Abs(distance) > (0.8f * (_camera.pixelHeight / (float)_ppu)))
                //{
                //    cameraPosition.y += 1.0f;
                //}
            }
            else
            {
                cameraPosition.y = 0;
            }

            gameObject.transform.position = cameraPosition;
        }
    }
}