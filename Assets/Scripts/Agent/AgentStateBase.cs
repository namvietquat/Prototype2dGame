using System;
using UnityEngine;

[Serializable]
public class AgentStateBase // POCO: Plain old c# object
{
    protected StateMachine _stateMachine;
    protected Rigidbody2D _rb;
    protected Animator _anim;
    protected bool _animationEventTrigger;
    public AgentStateBase(AgentController playerController)
    {
        _stateMachine = playerController.StateMachine;
        _rb = playerController.RB;
        _anim = playerController.Anim;
    }
    public virtual void Enter()
    {
        _animationEventTrigger = false;
    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {
        HandleAnimation();
    }

    protected virtual void HandleAnimation()
    {
        _anim.SetFloat("xInput", _rb.linearVelocity.x);
        _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }

    public void TriggerAnimationEvent()
    {
        _animationEventTrigger = true;
    }
}