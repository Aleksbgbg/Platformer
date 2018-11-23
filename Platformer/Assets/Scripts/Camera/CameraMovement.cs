namespace Scripts.Camera
{
    using UnityEngine;

    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float _movement = 5.0f;

        private void Update()
        {
            Vector3 cameraPosition = gameObject.transform.position;
            cameraPosition.x += _movement * Time.deltaTime;
            gameObject.transform.position = cameraPosition;
        }
    }
}