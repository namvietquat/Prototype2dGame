using UnityEngine;
using UnityEngine.InputSystem;
public class EnemyController : AgentController, IDamageable
{
    #region Serialized fields
    [SerializeField] private float _walkSpeed = 2.5f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _idleTime = 2f;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _detectRange;
    #endregion

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float IdleTime => _idleTime;
    public float AttackRange => _attackRange;

    #region States    
    public EnemyStateBase EnemyIdleState;
    public EnemyStateBase EnemyWalkState;
    public EnemyStateBase EnemyRunState;
    public EnemyStateBase EnemyFallState;
    public EnemyStateBase EnemyBattleState;
    public EnemyStateBase EnemyBasicAttackState;
    public EnemyStateBase EnemyHurtState;
    public EnemyStateBase EnemyDeathState;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        EnemyIdleState = new EnemyIdleState(this);
        EnemyWalkState = new EnemyWalkState(this);
        EnemyRunState = new EnemyRunState(this);
        EnemyFallState = new EnemyFallState(this);
        EnemyBattleState = new EnemyBattleState(this);
        EnemyBasicAttackState = new EnemyBasicAttackState(this);
        EnemyHurtState = new EnemyHurtState(this);
        EnemyDeathState = new EnemyDeathState(this);
        _stateMachine.ChangeState(EnemyIdleState);
    }

    public void Walk()
    {
        _rb.linearVelocity = new Vector2(_walkSpeed * FacingDirection, _rb.linearVelocity.y);
    }
    public void Run()
    {
        _rb.linearVelocity = new Vector2(_runSpeed * FacingDirection, _rb.linearVelocity.y);
    }
    public void BasicAttack()
    {
        
    }

    public RaycastHit2D PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(_detectGameobject.position, Vector2.right * FacingDirection, _detectRange, _playerLayer);
        if (hit.collider != null)
        {
            Debug.Log("Player detected");
            return hit;
        }
        return default;
    }

    public void OnDamage(float damage)
    {
        _health -= damage;
        _healthBar.SetValue(_health);
        _stateMachine.ChangeState(EnemyHurtState);
        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _stateMachine.ChangeState(EnemyDeathState);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawLine(_detectGameobject.position, _detectGameobject.position + Vector3.right * FacingDirection * _detectRange);
    }
}
