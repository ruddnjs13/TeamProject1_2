using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TargetLaserIdleState : TargetLaserState
{
    private TargetLaser _targetLaser;    

    public TargetLaserIdleState(TargetLaser targetLaser, LoopType loopType, Ease easeType) : base(targetLaser, loopType, easeType)
    {
        _targetLaser = targetLaser;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("아이들");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("아이들");
    }
}
