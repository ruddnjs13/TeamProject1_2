using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWallSatate : PlayerState
{
    public PlayerWallSatate(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.canFlip = false;
        _player.playerInput.JumpEvent += HandleJumpEvent;
    }

    public override void Exit()
    {
        _player.playerInput.JumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    private void HandleJumpEvent()
    {
        //_stateMachine.ChangeState(PlayerStateEnum.WallJump);
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
