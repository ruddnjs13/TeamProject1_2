using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public enum PlayerStateEnum
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
    public Dictionary<PlayerStateEnum, PlayerState> stateDictionary;

    private Player _player;

    public PlayerStateMachine()
    {
        stateDictionary = new Dictionary<PlayerStateEnum, PlayerState>();
    }

    public void Initialize(Player player, PlayerState startState)
    {
        _player = player;
        CurrentState = startState;
    }

    public void ChangeState(PlayerStateEnum nextState)
    {
        CurrentState.Exit();
        CurrentState = stateDictionary[nextState];
        CurrentState.Enter();
    }

    public void AddState(PlayerStateEnum stateEnum, PlayerState playerState)
    {
        stateDictionary.Add(stateEnum, playerState);
    }
}
