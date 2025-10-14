using UnityEngine;

public class RunState : StateBase
{
    public RunState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsGround", true);
        _player.SetFacingDirection(_player.MoveInput.x);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsGround", false);
    }
    public override void Update()
    {
        base.Update();
        _rb.linearVelocity = new Vector2(_player.MoveInput.x * _player.MoveSpeed, _rb.linearVelocity.y);
        if (_player.MoveInput.x == 0)
        {
            _stateMachine.ChangeState(_player.IdleState);
        }
        if (_player.JumpInput != 0)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _player.JumpForce * _player.JumpInput);
            _player.JumpInput = 0f;
            _stateMachine.ChangeState(_player.JumpState);
        }
        if (!_player.IsGroundDetect)
        {
            _stateMachine.ChangeState(_player.FallState);
        }
        if (_player.AttackInput != 0)
        {
            _player.AttackInput = 0f;
            _stateMachine.ChangeState(_player.BasicAttackState);
        }
    }
}