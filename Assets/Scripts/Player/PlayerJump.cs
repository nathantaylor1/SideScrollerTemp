using System;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 1.0f;
    public KeyCode jumpKey = KeyCode.Space;
    public LayerMask groundLayer;
    public float jumpRememberTime = 0.15f;
    public float groundedRememberTime = 0.15f;
    [Range(0, 1)] public float cutJumpHeight = 0.3f;
    
    [SerializeField] private bool grounded;
    private bool _canCheck = true;
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;
    private float timeSinceJumpPress, timeSinceGrounded;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateJumpButton();
        UpdateGrounded();
        UpdateVerticalVelocity();
    }

    private void UpdateJumpButton()
    {
        timeSinceJumpPress -= Time.deltaTime;
        if (Input.GetKeyDown(jumpKey))
        {
            timeSinceJumpPress = jumpRememberTime;
        }
        if (Input.GetKeyUp(jumpKey) && _rigidbody2D.velocity.y > 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * cutJumpHeight);
        }
    }
    
    private void UpdateGrounded()
    {
        timeSinceGrounded -= Time.deltaTime;
        grounded = CheckGrounded();
        if (_canCheck && grounded)
        {
            timeSinceGrounded = groundedRememberTime;
        }
    }

    private bool CheckJumpButtonPressedRecently()
    {
        return (timeSinceJumpPress > 0);
    }

    private bool CheckGroundedRecently()
    {
        return (timeSinceGrounded > 0);
    }

    private void UpdateVerticalVelocity()
    {
        if (!CheckGroundedRecently() || !CheckJumpButtonPressedRecently()) return;

        timeSinceGrounded = 0;
        timeSinceJumpPress = 0;
        Vector2 velocityUpdate = _rigidbody2D.velocity;
        velocityUpdate.y = jumpSpeed;
        _rigidbody2D.velocity = velocityUpdate;
        _canCheck = false;
        StartCoroutine(CO_WaitToCheck());
    }

    private bool CheckGrounded()
    {
        float yVel = _rigidbody2D.velocity.y;
        if (yVel == 0)
            return true;
        
        Bounds bounds = _collider2D.bounds;
        
        float width = bounds.extents.x - 0.05f;
        Vector3 size = new Vector3(width, 0.1f);
        
        float height = bounds.extents.y + 0.05f;

        return Physics2D.BoxCast(bounds.center, size, 0f, 
            Vector2.down, height, groundLayer);
    }

    private IEnumerator CO_WaitToCheck()
    {
        yield return new WaitForSeconds(0.2f);
        _canCheck = true;
        yield return null;
    }
}
