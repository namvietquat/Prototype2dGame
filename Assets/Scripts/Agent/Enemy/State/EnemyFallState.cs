using UnityEngine;

public class EnemyFallState : EnemyStateBase
{
    public EnemyFallState(EnemyController enemy) : base(enemy)
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
    }
}