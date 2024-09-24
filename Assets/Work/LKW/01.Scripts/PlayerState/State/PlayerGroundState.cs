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
        // 에어 스테이트로 변환
        //_stateMachine.ChangeState();
    }
}
