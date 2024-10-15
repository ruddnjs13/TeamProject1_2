using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerWallSatate
{
    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    private float _oringinGravity;

    public override void Enter()
    {
        base.Enter();
        _player.StopImmediately(true);
        _oringinGravity = _player.RbCompo.gravityScale;
        _player.RbCompo.gravityScale = 0;
    }

    public override void Exit()
    {
        _player.RbCompo.gravityScale = _oringinGravity;
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (Mathf.Abs(_player.playerInput.Movement.x) < 0.01f)
        {
            //_stateMachine.ChangeState(PlayerStateEnum.WallSlide);
        }
    }
}
