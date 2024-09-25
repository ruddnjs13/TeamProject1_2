using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public enum PlayerStateType
{
    Air,
    Ground,
    Idle,
    Move,
    Jump,
    Fall,
    Attack,
}

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }
    public Dictionary<PlayerStateType, PlayerState> stateDictionary;

    private Player _player;

    public PlayerStateMachine()
    {
        stateDictionary = new Dictionary<PlayerStateType, PlayerState>();
    }

    public void Initialize(Player player, PlayerState startState)
    {
        _player = player;
        CurrentState = startState;
    }

    public void ChangeState(PlayerStateType nextState)
    {
        CurrentState.Exit();
        CurrentState = stateDictionary[nextState];
        CurrentState.Enter();
    }

    public void AddState(PlayerStateType stateType, PlayerState playerState)
    {
        stateDictionary.Add(stateType, playerState);
    }
}
