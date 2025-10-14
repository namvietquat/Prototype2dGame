using UnityEngine;

public class WallSlideState : StateBase
{

    public WallSlideState(PlayerController player) : base(player)
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
        if (_player.MoveInput.y < 0)
        {
            _rb.linearVelocity = new Vector2(_player.MoveInput.x, _player.MoveInput.y);
        }
        else
        {
            _rb.linearVelocity = new Vector2(_player.MoveInput.x, _rb.linearVelocity.y * _player.WallSlideResistanceCoeff);
            
        }
        if (_player.JumpInput != 0)
        {
            _rb.linearVelocity = new Vector2(_player.WallJumpDirection.x * _player.FacingDirection * -1f, _player.WallJumpDirection.y);
            _player.SetFacingDirection(_player.FacingDirection*-1f);
            _player.JumpInput = 0f;
            _stateMachine.ChangeState(_player.JumpState);
        }
        if (_player.IsGroundDetect)
        {
            _player.SetFacingDirection(_player.FacingDirection * -1f);
            _stateMachine.ChangeState(_player.IdleState);
        }
        if (_player.IsWallDetected == false)
        {
            _stateMachine.ChangeState(_player.FallState);
        }

    }
}