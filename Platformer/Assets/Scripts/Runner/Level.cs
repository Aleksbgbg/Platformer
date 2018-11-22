namespace Scripts.Runner
{
    using UnityEngine;
    using UnityEngine.Tilemaps;

    internal class Level
    {
        private readonly Transform _transform;

        private readonly Tilemap _tilemap;

        private readonly TilemapRenderer _tilemapRenderer;

        internal Level(Transform transform)
        {
            _transform = transform;

            Grid grid = transform.GetComponent<Grid>();

            _tilemap = grid.GetComponentInChildren<Tilemap>();
            _tilemapRenderer = grid.GetComponentInChildren<TilemapRenderer>();
        }

        internal bool IsVisible => _tilemapRenderer.isVisible;

        internal float Size => _tilemap.size.x;

        internal void Destroy()
        {
            Object.Destroy(_transform.gameObject);
        }

        internal bool IsNearingEnd(Camera camera)
        {
            return camera.WorldToScreenPoint(new Vector3(_transform.position.x + (Size / 2.0f), 0.0f)).x <= camera.pixelWidth;
        }
    }
}