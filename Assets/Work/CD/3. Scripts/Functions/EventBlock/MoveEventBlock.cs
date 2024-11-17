using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveEventBlock : EventBlock
{
    [SerializeField] private float _duration;

    public override void VoidEvent()
    {
        base.VoidEvent();
        EventFunc();
    }

    protected override void EventFunc()
    {
        transform.DOMove(new Vector2(transform.position.x, 10), _duration);
    }
}
