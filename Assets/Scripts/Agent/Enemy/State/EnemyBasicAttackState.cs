using UnityEngine;

public class EnemyBasicAttackState : EnemyStateBase
{
    private int _comboAttackIndex = 1;
    private const int MAX_COMBO_INDEX = 3;

    public EnemyBasicAttackState(EnemyController enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsAttack", true);
        _comboAttackIndex = Random.Range(1, MAX_COMBO_INDEX + 1);
        _anim.SetInteger("BasicAttackIndex", _comboAttackIndex);
        _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsAttack", false);
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