using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 moveInput;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("MoveX", moveInput.x);
        _animator.SetFloat("MoveY", moveInput.y);
        _animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // 局聪皋捞记 肛勉 贸府
        _animator.speed = moveInput.sqrMagnitude > 0 ? 1 : 0;
    }

    void FixedUpdate()
    {
        if (_rigidbody != null)
        {
            _rigidbody.MovePosition(_rigidbody.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
