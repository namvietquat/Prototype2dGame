using System;
using UnityEngine;

[Serializable]
public class PlayerStateBase : AgentStateBase
{
    protected PlayerController _player;
    
    public PlayerStateBase(PlayerController playerController) : base(playerController)
    {
        _player = playerController;
        
    }
}