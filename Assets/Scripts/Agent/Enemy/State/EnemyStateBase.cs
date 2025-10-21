using System;
using UnityEngine;

[Serializable]
public class EnemyStateBase : AgentStateBase
{
    protected EnemyController _enemy;
    public EnemyStateBase(EnemyController enemyController) : base(enemyController)
    {
        
        _enemy = enemyController;
    }
    private void HandleAnimation()
    {
      _anim.SetFloat("xInput", _rb.linearVelocity.x);
      _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }
}