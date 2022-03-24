using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    
    private bool isRunning;
    private bool isJumping;
    private bool isFalling;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        if (isFalling)
            _animator.SetTrigger("Fall");
        else if (isJumping)
            _animator.SetTrigger("Jump");
        else if (isRunning)
            _animator.SetTrigger("Run");
        else
            _animator.SetTrigger("Idle");
    }

    public void SetRunning(bool input)
    {
        isRunning = input;
    }

    public void SetJumping(bool input)
    {
        isJumping = input;
    }
    
    public void SetFalling(bool input)
    {
        isFalling = input;
    }
}
