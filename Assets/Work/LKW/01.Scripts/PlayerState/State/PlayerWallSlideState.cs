using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerWallSatate
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
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
