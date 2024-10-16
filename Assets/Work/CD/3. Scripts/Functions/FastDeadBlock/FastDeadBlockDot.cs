using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class FastDeadBlockDot : MonoBehaviour
{
    [SerializeField] private float _position;
    [SerializeField] private float _delayUpSecond, _delayDownSecond;
    
    public float _duration;
    private float _previousPosition;

    private Tween _tween;
    public void Start()
    {
        _previousPosition = transform.position.y;
        StartCoroutine(MoveDot());
    }

    private void Update()
    {
        CheckBlock();
    }

    private void CheckBlock()
    {
    }

    private IEnumerator DelayCall()
    {
        yield return new WaitForSeconds(_delayUpSecond);
        _tween = transform.DOMove(new Vector2(transform.position.x, _previousPosition), _duration).SetEase(Ease.InQuart).OnComplete( () => StartCoroutine(MoveDot()) );
    }

    private IEnumerator MoveDot()
    {
        yield return new WaitForSeconds(_delayDownSecond);
        _tween = transform.DOMove(new Vector2(transform.position.x, _position), _duration).SetEase(Ease.OutQuart).OnComplete( () => StartCoroutine(DelayCall()) );
    }
}