using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public abstract class PlayerState
{
    protected Player _player;
    protected PlayerStateMachine _stateMachine;
    protected readonly int _animBoolHash;

    protected PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);
    }

    public virtual void  Enter()
    {
        _player.AnimatorCompo.SetBool(_animBoolHash,true);
   }

    public virtual void Exit()
    {
        _player.AnimatorCompo.SetBool(_animBoolHash,true);
    }

    public virtual void StateUpdate()
    {
        
    }

    public virtual void StateFixedUpdate()
    {
        
    }
}
