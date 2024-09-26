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
        _player.playerInput.JumpEvent += HandleJumpEvent;
    }

    private void HandleJumpEvent()
    {
        _stateMachine.ChangeState(PlayerStateEnum.WallJump);
    }
}
