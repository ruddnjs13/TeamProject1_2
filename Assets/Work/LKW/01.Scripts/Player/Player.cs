using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class Player : Agent
{
    #region MoveSettingRegion
    [Header("MoveSetting")] 
    public float _moveSpeed; 
    public float _wallJumpPower;
    #endregion

    #region JumpSetting
    public float _jumpPower;
    public float timeInAir = 0;
    public float _extraGravity = 10;
    public float _gravityDelay = 0.2f;
    #endregion
    
    [SerializeField] private InputReaderSO _inputReader;
    public InputReaderSO playerInput => _inputReader;
    

    public UnityEvent OnDeadEvent;

    
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
        CheckGround();
        Flip(playerInput.Movement.x);
        StateMachine.CurrentState.StateUpdate();
    }

    private void LateUpdate()
    {
    }

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StateMachine.ChangeState(PlayerStateEnum.Dead);
        }
    }

    
}