using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        UpdatePlayerDirection();
    }

    private void UpdatePlayerDirection()
    {
        _spriteRenderer.flipX = !_playerMovement.GetFacingRight();
    }
}
