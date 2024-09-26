using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player player,PlayerStateMachine stateMachine ,string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    

    public override void Enter()
    {
        _player.StopImmediately(false);
    }
    

    public override void StateUpdate()
    {
        base.StateUpdate();

        float xMove = _player.playerInput.Movement.x;

        if (Mathf.Abs(xMove) > 0)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }
}
