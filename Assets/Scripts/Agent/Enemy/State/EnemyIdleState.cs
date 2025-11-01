using UnityEngine;

public class EnemyIdleState : EnemyGroundState
{
    public EnemyIdleState(EnemyController player) : base(player)
    {
    }

    public override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            _controller.SetFacingDirection(_controller.FacingDirection * -1);
            _stateMachine.ChangeState(_controller.EnemyWalkState);
        }
    }
}