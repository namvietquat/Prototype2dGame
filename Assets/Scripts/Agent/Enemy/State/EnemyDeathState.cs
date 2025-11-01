using UnityEngine;

public class EnemyDeathState : EnemyStateBase
{
    public EnemyDeathState(EnemyController enemy) : base(enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsDeath", true);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsDeath", false);
    }
    public override void Update()
    {
        base.Update();
        // stateMachine.Shutdown();
    }
}