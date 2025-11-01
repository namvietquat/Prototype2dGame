using UnityEngine;

public class EnemyHurtState : EnemyStateBase
{
    public EnemyHurtState(EnemyController enemy) : base(enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsHurt", true);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsHurt", false);
    }
    public override void Update()
    {
        base.Update();
        if (_animationEventTrigger)
        {
            _stateMachine.ChangeState(_controller.EnemyBattleState);
        }
    }
}