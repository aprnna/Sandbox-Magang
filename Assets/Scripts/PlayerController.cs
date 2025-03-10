using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _speed = 3f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        _rigidbody.linearVelocity = value.Get<Vector2>() * _speed;
    }
}
