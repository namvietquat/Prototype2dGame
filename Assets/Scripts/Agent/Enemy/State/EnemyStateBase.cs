using System;
using UnityEngine;

[Serializable]
public class EnemyStateBase : AgentStateBase
{
    protected EnemyController _controller;
    public EnemyStateBase(EnemyController enemyController) : base(enemyController)
    {
        _controller = enemyController;
    }

    protected override void HandleAnimation()
    {
        _anim.SetFloat("xInput", _rb.linearVelocity.x / _controller.RunSpeed);
        _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }
}