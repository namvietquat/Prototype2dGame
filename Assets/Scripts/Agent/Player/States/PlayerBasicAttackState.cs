using UnityEngine;

public class PlayerBasicAttackState : PlayerStateBase
{
    private int _comboAttackIndex = 1;
    private const int MAX_COMBO_INDEX = 3;
    private float _lastAttackTime;
    private float _comboChainTime = 1f;

    public PlayerBasicAttackState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsAttack", true);
        _comboAttackIndex++;
        if (Time.time > _lastAttackTime + _comboChainTime
            || _comboAttackIndex > MAX_COMBO_INDEX)
        {
            _comboAttackIndex = 1;
        }
        _anim.SetInteger("BasicAttackIndex", _comboAttackIndex);
        _player.SetFacingDirection(_player.MoveInput.x);
        _lastAttackTime = Time.time;
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsAttack", false);
    }
    public override void Update()
    {
        base.Update();
        _rb.linearVelocity = new Vector2(_player.AttackPushForce * _player.FacingDirection, _rb.linearVelocity.y);
        if (_animationEventTrigger)
        {
            _stateMachine.ChangeState(_player.PlayerIdleState);
        }
        if (!_player.IsGroundDetect && _rb.linearVelocity.y < 0)
        {
            _stateMachine.ChangeState(_player.PlayerFallState);
        }
    }
}