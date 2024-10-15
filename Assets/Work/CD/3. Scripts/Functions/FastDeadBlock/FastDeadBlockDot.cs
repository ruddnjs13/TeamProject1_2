using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FastDeadBlockDot : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private float _delaySecond;
    
    public float _duration;
    

    public void Start()
    {
        MoveDot();
    }

    private void Update()
    {
        CheckDo();
    }

    private void CheckDo()
    {
        
    }

    private IEnumerator DelayCall()
    {
        yield return new WaitForSeconds(_delaySecond);
        
    }

    public void MoveDot()
    {
        transform.DOMove(_position, _duration).SetEase(Ease.InQuad).SetLoops(-1, LoopType.Yoyo);
    }
}
