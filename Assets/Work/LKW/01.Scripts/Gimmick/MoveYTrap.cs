using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveYTrap : MonoBehaviour
{
    [SerializeField] private float moveYDistance = 2f;
    [SerializeField] private float moveDuration = 1.5f;
    
    private Sequence moveSequence;

    private void OnEnable()
    {
        moveSequence.Append(transform.DOLocalMoveY(transform.localPosition.y + moveYDistance
            , moveDuration,false).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo));
        moveSequence.AppendInterval(0.2f);
    }

    private void OnDisable()
    {
        this.transform.DOKill();
    }
}