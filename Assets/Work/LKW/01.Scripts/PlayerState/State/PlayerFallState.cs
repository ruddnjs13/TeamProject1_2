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
        _player.SetMovement(new Vector2(_player.playerInput.Movement.x * _player._moveSpeed,_player.RbCompo.velocity.y));
        if (_player.IsGround.Value)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }
}
