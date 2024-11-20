using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveXTrap : MonoBehaviour
{
    [SerializeField] private float moveXDistance = 2f;
    [SerializeField] private float moveDuration = 1.5f;
    
    private Sequence _moveSequence;

    private void OnEnable()
    {
        _moveSequence = DOTween.Sequence();
        _moveSequence.Append(transform.DOLocalMoveX(transform.localPosition.x + moveXDistance
            , moveDuration,false).SetEase(Ease.Linear));
        _moveSequence.Append(transform.DOLocalMoveX(transform.localPosition.x
            , moveDuration, false).SetEase(Ease.Linear));
        _moveSequence.AppendInterval(0.2f);
        _moveSequence.SetLoops(-1);
    }

    private void OnDisable()
    {
        this.transform.DOKill();
    }
}
