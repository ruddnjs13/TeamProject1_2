using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public enum PlayerStateType
{
    Idle,
    Move,
    Jump,
    Fall,
    Attack,
}

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }
    public Dictionary<PlayerStateType, PlayerState> StateDictionary;

    private Player _player;

    public PlayerStateMachine()
    {
        StateDictionary = new Dictionary<PlayerStateType, PlayerState>();
    }

    public void Initialize(Player player, PlayerState startState)
    {
        _player = player;
        CurrentState = startState;
    }

    public void ChangeState(PlayerStateType nextState)
    {
        CurrentState.Extit();
        CurrentState = StateDictionary[nextState];
        CurrentState.Enter();
    }

    public void AddState(PlayerStateType stateType, PlayerState playerState)
    {
        
    }
}
