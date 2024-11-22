using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/FSM/TargetLaserStatesSO")]
public class TargetLaserStatesSO : ScriptableObject
{
    public List<TargetLaserStateSO> targetLaserStates;
    
    private Dictionary<string, TargetLaserStateSO> _statesDic;

    public TargetLaserStateSO this[string stateName]
        => _statesDic.GetValueOrDefault(stateName);

    private void OnEnable()
    {
        if (targetLaserStates == null) return;
        
        _statesDic = new Dictionary<string, TargetLaserStateSO>();
        foreach (TargetLaserStateSO state in targetLaserStates)
            _statesDic.Add(state.stateName, state);
    }
}
