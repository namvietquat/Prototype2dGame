using System;
using UnityEngine;

[Serializable]
public class StateBase // POCO: Plain old c# object
{
    protected PlayerController _player;
    protected StateMachine _stateMachine;
    protected Rigidbody2D _rb;
    protected Animator _anim;
    protected bool _triggerEvent;
    public bool TriggerEvent { get => _triggerEvent; set => _triggerEvent = value;  }
    public StateBase(PlayerController playerController)
    {
        _player = playerController;
        _stateMachine = playerController.StateMachine;
        _rb = _player.RB;
        _anim = _player.Anim;
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