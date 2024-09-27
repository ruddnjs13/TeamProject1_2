using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.playerInput.JumpEvent += HandleJumpEvent;
    }

    public override void Exit()
    {
        _player.playerInput.JumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    private void HandleJumpEvent()
    {
        if (_player.IsGround.Value)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Jump);
        }
    }
}
