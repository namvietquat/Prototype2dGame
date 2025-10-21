using UnityEngine;

public class PlayerFallState : PlayerStateBase
{
    public PlayerFallState(PlayerController player) : base(player)
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
        if (_player.IsGroundDetect)
        {
            _stateMachine.ChangeState(_player.IdleState);
        }
        if (_player.IsWallDetected)
        {
            _stateMachine.ChangeState(_player.WallSlideState);
        }
    }
}