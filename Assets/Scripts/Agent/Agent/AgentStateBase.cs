using System;
using UnityEngine;

[Serializable]
public class AgentStateBase
{
   
    protected StateMachine _stateMachine;
    protected Rigidbody2D _rb;
    protected Animator _anim;
    protected bool _triggerEvent;
    public bool TriggerEvent { get => _triggerEvent; set => _triggerEvent = value;  }
    public AgentStateBase(AgentController playerController)
    {
        _stateMachine = playerController.StateMachine;
        _rb =  playerController.RB;
        _anim =  playerController.Anim;
    }
    public virtual void Enter()
    {
        _triggerEvent = false;
    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        _anim.SetFloat("xInput", _rb.linearVelocity.x);
        _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }
}