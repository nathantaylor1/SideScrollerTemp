using UnityEngine;

public class SetCameraCollider : MonoBehaviour
{
    private Camera _camera;
    private BoxCollider2D _boxCollider2D;
    private float _x, _y, _ratio;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        UpdateSize();
        _boxCollider2D.size = new Vector2(_x, _y);
    }

    private void UpdateSize()
    {
        _y = _camera.orthographicSize * 2;
        _ratio = (float) Screen.width / (float) Screen.height;
        _x = _y * _ratio;
    }
}
