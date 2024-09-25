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
        _player.IsGround.OnValueChanged += HandleGroundChange;
    }

    private void HandleGroundChange(bool prev, bool next)
    {
        _stateMachine.ChangeState(PlayerStateType.Air);
    }

    public override void Exit()
    {
        _player.IsGround.OnValueChanged -= HandleGroundChange;
        base.Exit();
    }
}
