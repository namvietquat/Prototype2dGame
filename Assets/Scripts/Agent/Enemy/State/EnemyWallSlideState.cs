using UnityEngine;

public class EnemyWallSlideState : EnemyStateBase
{

    public EnemyWallSlideState(EnemyController enemy) : base(enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsWallSlide", true);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsWallSlide", false);
    }

    public override void Update()
    {
        base.Update();
        if (_enemy.MoveInput.y < 0)
        {
            _rb.linearVelocity = new Vector2(_enemy.MoveInput.x, _enemy.MoveInput.y);
        }
        else
        {
            _rb.linearVelocity = new Vector2(_enemy.MoveInput.x, _rb.linearVelocity.y * _enemy.WallSlideResistanceCoeff);
            
        }
        if (_enemy.JumpInput != 0)
        {
            _rb.linearVelocity = new Vector2(_enemy.WallJumpDirection.x * _enemy.FacingDirection * -1f, _enemy.WallJumpDirection.y);
            _enemy.SetFacingDirection(_enemy.FacingDirection*-1f);
            _enemy.JumpInput = 0f;
            _stateMachine.ChangeState(_enemy.JumpState);
        }
        if (_enemy.IsGroundDetect)
        {
            _enemy.SetFacingDirection(_enemy.FacingDirection * -1f);
            _stateMachine.ChangeState(_enemy.IdleState);
        }
        if (_enemy.IsWallDetected == false)
        {
            _stateMachine.ChangeState(_enemy.FallState);
        }

    }
}