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
        CalculateTime();
        ApplyExtraGravity();
        
    }
    
    private void CalculateTime()
    {
        if (!_player.IsGround.Value)
        {
            _player.timeInAir += Time.deltaTime;
        }
        else
        {
            _player.timeInAir = 0;
        }
    }

    private void ApplyExtraGravity()
    {
        if (_player.timeInAir > _player._gravityDelay)
        {
            _player.RbCompo.AddForce(Vector2.down * _player._extraGravity, ForceMode2D.Impulse);
            _player.timeInAir = 0f;
        }
    }
}
