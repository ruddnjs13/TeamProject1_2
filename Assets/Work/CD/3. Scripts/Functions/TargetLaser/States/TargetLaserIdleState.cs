using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLaserIdleState : TargetLaserState
{
    private TargetLaser _targetLaser;


    public TargetLaserIdleState(TargetLaser targetLaser) : base(targetLaser)
    {
        _targetLaser = targetLaser;
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("아이들");
    }
}
