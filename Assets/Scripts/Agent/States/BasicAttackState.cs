using UnityEngine;

public class BasicAttackState : StateBase
{
    private int _currentAttackIndex = 0;
    private const int MAX_INDEX = 3;
    private float _lastAttackTime;
    private float _comboChainTime = 1f;
    public BasicAttackState(PlayerController playerController) : base(playerController)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsAttack", true);
        if (Time.time > _lastAttackTime + _comboChainTime)
        {
            _currentAttackIndex = 0;
        }
        if (_currentAttackIndex >= MAX_INDEX)
        {
            _currentAttackIndex = 0;
        }
        _currentAttackIndex++;
        _lastAttackTime = Time.time;
        _anim.SetInteger("BasicAttackIndex", _currentAttackIndex);
        _rb.linearVelocity = new Vector2(_player.AttackPushForce.x * _player.FacingDirection, _player.AttackPushForce.y);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsAttack", false);
    }
    public override void Update()
    {
        base.Update();
        if (_triggerEvent)
        {
            _stateMachine.ChangeState(_player.IdleState);
        }
    }
}