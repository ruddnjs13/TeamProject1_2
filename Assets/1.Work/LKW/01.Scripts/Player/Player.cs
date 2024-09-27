using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : Agent
{
    #region MoveSettingRegion
    [Header("MoveSetting")] 
    public float _moveSpeed; 
    public float _jumpPower;
    public float _wallJumpPower;
    #endregion

    

    [SerializeField] private InputReaderSO _inputReader;
    public InputReaderSO playerInput => _inputReader;


    
    public PlayerStateMachine StateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        AnimatorCompo = GetComponentInChildren<Animator>();
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
    
    private void Start()
    {
        StateMachine.Initialize(this, PlayerStateEnum.Idle);
    }

    protected void Update()
    {
        Flip(playerInput.Movement.x);
        CheckGround();
        StateMachine.CurrentState.StateUpdate();
    }
    
   
}