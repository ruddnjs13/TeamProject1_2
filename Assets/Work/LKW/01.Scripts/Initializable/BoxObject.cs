using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : InitializeObject
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log(_originLocalPos);
        Debug.Log(_originLocalRot);
    }

    public override void Initialize()
    {
        base.Initialize();
    }
}
