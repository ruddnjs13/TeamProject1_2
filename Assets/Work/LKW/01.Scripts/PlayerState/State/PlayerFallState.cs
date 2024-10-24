using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (_player.IsGround.Value)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }
}
