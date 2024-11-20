using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class TargetLaserState
{
    protected TargetLaser _targetLaser;
    protected LoopType _loopType;
    protected Ease _easeType;
    
    public TargetLaserState(TargetLaser targetLaser, LoopType loopType, Ease easeType)
    {
        _targetLaser = targetLaser;
        _loopType = loopType;
        _easeType = easeType;
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
