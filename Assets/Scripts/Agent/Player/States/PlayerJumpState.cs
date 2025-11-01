using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    public PlayerJumpState(PlayerController player) : base(player)
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
            _stateMachine.ChangeState(_player.PlayerFallState);
        }
        if (_player.IsGroundDetect)
        {
            _stateMachine.ChangeState(_player.PlayerIdleState);
        }
        if (_player.IsWallDetected)
        {
            _stateMachine.ChangeState(_player.PlayerWallSlideState);
        }
    }
}