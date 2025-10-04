using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region Input
    private Vector2 _moveInput;
    private float _jumpInput;
    private float _attackInput;
    private Rigidbody2D _rb;
    #endregion
    
    
    [SerializeField] private float moveSpeed = 5f;
    
    
    public void Move(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _jumpInput = ctx.ReadValue<float>();
        }
    }
    public void BasicAttack(InputAction.CallbackContext ctx)
    {
        _attackInput = ctx.ReadValue<float>();
    }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * moveSpeed;
    }
}
