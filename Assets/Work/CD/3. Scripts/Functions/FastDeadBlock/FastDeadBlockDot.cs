using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class FastDeadBlockDot : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private float _delayUpSecond, _delayDownSecond;
    
    public float _duration;
    private Vector2 _previousPosition;

    private Tween _tween;
    public void Start()
    {
        _previousPosition = transform.position;
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
        Debug.Log("Delay call");
        _tween = transform.DOMove(_previousPosition, _duration).SetEase(Ease.InQuart).OnComplete( () => StartCoroutine(MoveDot()) );
    }

    private IEnumerator MoveDot()
    {
        yield return new WaitForSeconds(_delayDownSecond);
        _tween = transform.DOMove(_position, _duration).SetEase(Ease.OutQuart).OnComplete( () => StartCoroutine(DelayCall()) );
    }
}