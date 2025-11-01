using UnityEngine;

public class EnemyWalkState : EnemyGroundState
{
    public EnemyWalkState(EnemyController player) : base(player)
    {
    }

    public override void Update()
    {
        base.Update();
        _controller.Walk();
        if (!_controller.IsGroundDetect || _controller.IsWallDetected)
        {
            _rb.linearVelocity = Vector2.zero;
            _stateMachine.ChangeState(_controller.EnemyIdleState);
        }
    }
}