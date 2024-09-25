using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    #region MoveSettingRegion
    [Header("MoveSetting")] 
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    #endregion

    [SerializeField] private InputReaderSO _inputReader;
    public InputReaderSO playerInput => _inputReader;
    
    public PlayerStateMachine StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();

            Type type = Type.GetType($"Player{typeName}State");

            if (type != null)
            {
                PlayerState state = Activator.CreateInstance(type, this, StateMachine, typeName) as PlayerState;
                StateMachine.AddState(stateEnum, state);
            }
        }
    }

    private void Update()
    {
        StateMachine.CurrentState.StateUpdate();
    }
}