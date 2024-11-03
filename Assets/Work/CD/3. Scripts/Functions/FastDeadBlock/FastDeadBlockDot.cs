using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FastDeadBlockDot : MonoBehaviour
{
    public UnityEvent OnHit;
    
    [SerializeField] private float _position;
    [SerializeField] private float _delayUpSecond;
    
    public float _duration;

    private Tween _tween, _tween2;
    private Sequence _sequence;
    private float _pos;
    
    public void Start()
    {
        SetSequence();
    }

    public void StopMove()
    {
        _sequence.Pause();
    }
    
    public void SetSequence()
    {
        _pos = transform.localPosition.x;
        _tween = transform.DOMove(new Vector2(_pos, _position), _duration).SetEase(Ease.OutQuart);

        _sequence = DOTween.Sequence();
        _sequence.AppendInterval(_delayUpSecond)
            .Append(_tween)
            .AppendInterval(_delayUpSecond);
        _sequence.SetLoops(-1, LoopType.Yoyo);
    }

    public void EndMove()
    {
        _sequence.Play();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer ==LayerMask.NameToLayer("Player"))
        {
            OnHit?.Invoke();
        }
    }
}