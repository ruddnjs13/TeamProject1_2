using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class TargetLaserStateMachine : MonoBehaviour
{
    
    private Dictionary<string, TargetLaserState> _states;
    public TargetLaserState CurrentState { get; set; }

    public TargetLaserStateMachine(TargetLaserStatesSO targetLaserFSM, TargetLaser owner)
    {
        _states = new Dictionary<string, TargetLaserState>();
        
        foreach (TargetLaserStateSO state in targetLaserFSM.targetLaserStates)
        {
            try
            {
                Type type = Type.GetType(state.className);
                var targetLaser = Activator.CreateInstance(type, owner, state.loopType, state._easeType) as TargetLaserState;
                
                _states.Add(state.stateName, targetLaser);
            }
            catch (Exception ex)
            {
                Debug.Log(state);
                Debug.LogError($"<color=red>{state.className}</color> loading error : {ex.Message}");
            }
        }
    }

    public void UpdateState()
    {
        CurrentState.Update();
    }

    public TargetLaserState GetState(string name)
    {
        return _states.GetValueOrDefault(name);
    }

    public void Initialize(string stateName)
    {
        TargetLaserState state = GetState(stateName);
        Debug.Assert(state != null, $"Start state {stateName} is Null");
        
        CurrentState = state;
        CurrentState.Enter();
    }

    public void ChangeState(string stateName)
    {
        CurrentState.Exit();
        TargetLaserState state = GetState(stateName);
        Debug.Assert(state != null, $"State {stateName} not Found");
        
        CurrentState = state;
        CurrentState.Enter();
    }
}
