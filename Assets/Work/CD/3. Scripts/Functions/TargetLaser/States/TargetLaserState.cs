using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetLaserState
{
    protected TargetLaser _targetLaser;
    
    public TargetLaserState(TargetLaser targetLaser)
    {
        _targetLaser = targetLaser;
    }

    public virtual void Enter()
    {
        
        
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        
    }
}
