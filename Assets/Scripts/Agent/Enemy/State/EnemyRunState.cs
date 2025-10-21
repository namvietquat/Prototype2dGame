using UnityEngine;

public class EnemyRunState : EnemyStateBase
{
    public EnemyRunState(EnemyController enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsGround", true);
        _enemy.SetFacingDirection(_enemy.MoveInput.x);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsGround", false);
    }
    public override void Update()
    {
        base.Update();
        _rb.linearVelocity = new Vector2(_enemy.MoveInput.x * _enemy.MoveSpeed, _rb.linearVelocity.y);
        if (_enemy.MoveInput.x == 0)
        {
            _stateMachine.ChangeState(_enemy.IdleState);
        }
        if (_enemy.JumpInput != 0)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _enemy.JumpForce * _enemy.JumpInput);
            _enemy.JumpInput = 0f;
            _stateMachine.ChangeState(_enemy.JumpState);
        }
        if (!_enemy.IsGroundDetect)
        {
            _stateMachine.ChangeState(_enemy.FallState);
        }
        if (_enemy.AttackInput != 0)
        {
            _enemy.AttackInput = 0f;
            _stateMachine.ChangeState(_enemy.BasicAttackState);
        }
    }
}