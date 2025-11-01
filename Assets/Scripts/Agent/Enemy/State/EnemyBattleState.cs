using UnityEngine;

public class EnemyBattleState : EnemyStateBase
{
    private Transform _player;
    public EnemyBattleState(EnemyController enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsBattle", true);
        if (_player == null)
        {
            _player = _controller.PlayerDetected().transform;
        }
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsBattle", false);
    }
    public override void Update()
    {
        base.Update();

        if (IsInAttackRange())
        {
            _stateMachine.ChangeState(_controller.EnemyBasicAttackState);
        }
        else
        {
            Chase();
        }
    }

    private bool IsInAttackRange()
    {
        return Mathf.Abs(_controller.transform.position.x - _player.position.x) < _controller.AttackRange;
    }

    private void Chase()
    {
        _controller.SetFacingDirection(ChasingDirection());
        _rb.linearVelocity = new Vector2(_controller.RunSpeed * ChasingDirection(), _rb.linearVelocity.y);
    }

    private float ChasingDirection()
    {
        return _controller.transform.position.x > _player.position.x
                    ? -1f
                    : 1f;
    }
}