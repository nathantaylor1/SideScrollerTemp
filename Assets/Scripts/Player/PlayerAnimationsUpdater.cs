using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsUpdater : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Animator _anim;
    private int _animYVelHash, _animXVelHash;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _animYVelHash = Animator.StringToHash("yVelocity");
        _animXVelHash = Animator.StringToHash("xVelocity");
    }

    private void Update()
    {
        _anim.SetFloat(_animYVelHash, _rb2d.velocity.y);
        _anim.SetFloat(_animXVelHash, Mathf.Abs(_rb2d.velocity.x));
    }
}
