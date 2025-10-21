using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class EnemyController : AgentController
{
    private StateMachine _stateMachine;
    private Rigidbody2D _rb;
    public Rigidbody2D RB => _rb;
    private Animator _animator;

    #region Input
    private Vector2 _moveInput;
    private float _jumpInput;
    private float _attackInput;
    #endregion

    #region Detection flags
    private bool _isGroundDetect;
    private bool _isWallDetected;
    #endregion

    #region Serialized fields
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] private float _detectGroundDistance = 0.7f;
    [SerializeField] private float _detectWallDistance = 0.3f;
    [SerializeField] private float _wallSlideResistanceCoeff = 0.5f;
    [SerializeField] private Vector2 _wallJumpDirection = new Vector2(6f, 15f);
    [SerializeField] private Vector2 _attackPushForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _wallLayer;
    #endregion

    #region Public properties
    public Animator Anim => _animator;
    public bool IsGroundDetect => _isGroundDetect;
    public bool IsWallDetected => _isWallDetected;
    public Vector2 MoveInput => _moveInput;
    public float JumpInput { get => _jumpInput; set => _jumpInput = value; }
    public float AttackInput { get => _attackInput; set => _attackInput = value; }
    public Vector2 AttackPushForce => _attackPushForce;
    public StateMachine StateMachine => _stateMachine;
    public float MoveSpeed => _moveSpeed;
    public float JumpForce => _jumpForce;
    public float WallSlideResistanceCoeff => _wallSlideResistanceCoeff;
    public Vector2 WallJumpDirection => _wallJumpDirection;
    public float FacingDirection => transform.localScale.x;
    #endregion

    #region States    
    public EnemyStateBase EnemyIdleState;
    public EnemyStateBase EnemyRunState;
    public EnemyStateBase EnemyBasicAttackState;
    #endregion

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _stateMachine = new StateMachine();

        EnemyIdleState = new EnemyIdleState(this);
        EnemyRunState = new EnemyRunState(this);
     
        EnemyBasicAttackState = new EnemyBasicAttackState(this);
        _stateMachine.ChangeState(EnemyIdleState);
    }
    void Update()
    {
        _stateMachine.CurrentState.Update();
        DetectGround();
        DetectWall();
    }


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

    public void SetFacingDirection(float direction)
    {
        if (direction == 0)
        {
            return;
        }
        if (direction > 0 != transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1f, 1f);
        }
    }

    private void DetectGround()
    {
        List<RaycastHit2D> hit = new();
        var filter = new ContactFilter2D
        {
            layerMask = _groundLayer,
            useLayerMask = true
        };
        if (Physics2D.Raycast(transform.position, Vector2.down, filter, hit, _detectGroundDistance) > 0)
        {
            _isGroundDetect = true;
        }
        else
        {
            _isGroundDetect = false;
        }
    }

    private void DetectWall()
    {
        List<RaycastHit2D> hit = new();
        var filter = new ContactFilter2D
        {
            layerMask = _wallLayer,
            useLayerMask = true
        };
        if (Physics2D.Raycast(transform.position, Vector2.right * FacingDirection, filter, hit, _detectWallDistance) > 0)
        {
            _isWallDetected = true;
        }
        else
        {
            _isWallDetected = false;
        }
    }

    public void CallAnimationEvent()
    {
        _stateMachine.CurrentState.TriggerEvent = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _detectGroundDistance);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * _detectWallDistance * FacingDirection);
    }
}
