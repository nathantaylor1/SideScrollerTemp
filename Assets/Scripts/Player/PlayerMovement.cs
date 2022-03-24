using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft  = KeyCode.A;
    
    private bool _facingRight;
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimationController _playerAnimController;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimController = GetComponent<PlayerAnimationController>();
    }

    private void Update()
    {
        UpdateHorizontalVelocity();
    }

    private int GetHorizontalInput()
    {
        int hInput = (Input.GetKey(moveRight) ? 1 : 0) + (Input.GetKey(moveLeft) ? -1 : 0);
        
        if (hInput == 1) _facingRight = true;
        else if (hInput == -1) _facingRight = false;
        // else: Dont update facingRight to keep player facing that direction
        
        return hInput;
    }

    private void UpdateHorizontalVelocity()
    {
        Vector2 velocityUpdate = _rigidbody2D.velocity;
        velocityUpdate.x = GetHorizontalInput() * moveSpeed;
        _rigidbody2D.velocity = velocityUpdate;
        
        _playerAnimController.SetRunning(velocityUpdate.x != 0);
    }

    public bool GetFacingRight()
    {
        return _facingRight;
    }
}
