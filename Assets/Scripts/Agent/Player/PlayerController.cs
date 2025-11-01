using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : AgentController, IDamageable
{
    #region Input
    private Vector2 _moveInput;
    private float _jumpInput;
    private float _attackInput;
    public Vector2 MoveInput => _moveInput;
    public float JumpInput { get => _jumpInput; set => _jumpInput = value; }
    public float AttackInput { get => _attackInput; set => _attackInput = value; }
    #endregion

    #region Serialized fields
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 2f;
    
    [SerializeField] private float _wallSlideResistanceCoeff = 0.5f;
    [SerializeField] private float _attackPushForce = 0.5f;
    [SerializeField] private Vector2 _wallJumpDirection = new Vector2(6f, 10f);
    #endregion

    public float MoveSpeed => _moveSpeed;
    public float JumpForce => _jumpForce;
    public float AttackPushForce => _attackPushForce;
    public float WallSlideResistanceCoeff => _wallSlideResistanceCoeff;
    public Vector2 WallJumpDirection => _wallJumpDirection;

    #region States    
    public PlayerStateBase PlayerIdleState;
    public PlayerStateBase PlayerRunState;
    public PlayerStateBase PlayerJumpState;
    public PlayerStateBase PlayerFallState;
    public PlayerStateBase PlayerWallSlideState;
    public PlayerStateBase PlayerBasicAttackState;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        PlayerIdleState = new PlayerIdleState(this);
        PlayerRunState = new PlayerRunState(this);
        PlayerJumpState = new PlayerJumpState(this);
        PlayerFallState = new PlayerFallState(this);
        PlayerWallSlideState = new PlayerWallSlideState(this);
        PlayerBasicAttackState = new PlayerBasicAttackState(this);
        _stateMachine.ChangeState(PlayerIdleState);
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
        if (ctx.started)
        {
            _attackInput = ctx.ReadValue<float>();
        }
    }
    public void OnDamage(float damage)
    {
        _health -= damage;
    }
}
