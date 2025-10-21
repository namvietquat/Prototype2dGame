using UnityEngine;

public class EnemyJumpState : EnemyStateBase
{
    public EnemyJumpState(EnemyController enemyController) : base(enemyController)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsJump", true);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsJump", false);
    }
    public override void Update()
    {
        base.Update();
        if (_rb.linearVelocity.y < 0)
        {
            _stateMachine.ChangeState(_enemy.FallState);
        }
        if (_enemy.IsGroundDetect)
        {
            _stateMachine.ChangeState(_enemy.IdleState);
        }
        if (_enemy.IsWallDetected)
        {
            _stateMachine.ChangeState(_enemy.WallSlideState);
        }
    }
}