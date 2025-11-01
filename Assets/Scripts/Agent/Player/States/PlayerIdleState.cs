using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{
    public PlayerIdleState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsGround", true);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsGround", false);
    }

    public override void Update()
    {
        base.Update();
        if (_player.MoveInput.x != 0)
        {
            _stateMachine.ChangeState(_player.PlayerRunState);
        }
        if (_player.JumpInput != 0)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _player.JumpForce * _player.JumpInput);
            _player.JumpInput = 0f;
            _stateMachine.ChangeState(_player.PlayerJumpState);
        }
        if (!_player.IsGroundDetect)
        {
            _stateMachine.ChangeState(_player.PlayerFallState);
        }
        if (_player.AttackInput != 0)
        {
            _player.AttackInput = 0f;
            _stateMachine.ChangeState(_player.PlayerBasicAttackState);
        }
    }
}