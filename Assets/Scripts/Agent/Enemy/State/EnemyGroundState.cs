using UnityEngine;

public class EnemyGroundState : EnemyStateBase
{
    protected float timer;
    public EnemyGroundState(EnemyController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsGround", true);
        timer = _controller.IdleTime;
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsGround", false);
    }

    public override void Update()
    {
        base.Update();
        if (_controller.PlayerDetected())
        {
            _stateMachine.ChangeState(_controller.EnemyBattleState);
        }
    }
}