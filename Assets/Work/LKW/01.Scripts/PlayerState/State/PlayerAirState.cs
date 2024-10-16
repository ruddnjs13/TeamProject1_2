using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player,PlayerStateMachine stateMachine ,string animBoolName) : base(player,stateMachine ,animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.canFlip = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (Mathf.Abs(_player.playerInput.Movement.x) > 0 && 
            _player.CheckWall(_player.playerInput.Movement.x))
        {
            //_stateMachine.ChangeState(PlayerStateEnum.WallGrab);
        }
    }
}
