using UnityEngine;

public class EnemyIdleState : EnemyStateBase
{
    public EnemyIdleState(EnemyController enemy) : base(enemy)
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
        if (_enemy.MoveInput.x != 0)
        {
            _stateMachine.ChangeState(_enemy.EnemyRunState);
        }
        
        if (_enemy.AttackInput != 0)
        {
            _enemy.AttackInput = 0f;
            _stateMachine.ChangeState(_enemy.EnemyBasicAttackState);
        }
    }
}