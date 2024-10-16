using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.RbCompo.AddForce(Vector2.up * _player._jumpPower, ForceMode2D.Impulse);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (_player._isDashing) return;
            _player.SetMovement(new Vector2(_player.playerInput.Movement.x * _player._moveSpeed,_player.RbCompo.velocity.y));
        if (_player.RbCompo.velocity.y < -0)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }
}
