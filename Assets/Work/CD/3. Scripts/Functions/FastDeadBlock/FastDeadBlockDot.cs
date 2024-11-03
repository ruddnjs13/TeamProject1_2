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
    private Transform _pos;
    
    public void Start()
    {
        SetSequence();
    }

    public void StopMove()
    {
        Debug.Log("Invoke");
        _tween.Kill();
        _sequence.Kill();
    }
    
    public void SetSequence()
    {
        _tween = transform.DOMove(new Vector2(transform.position.x, _position), _duration).SetEase(Ease.OutQuart);

        _sequence = DOTween.Sequence();
        _sequence.AppendInterval(_delayUpSecond)
            .Append(_tween)
            .AppendInterval(_delayUpSecond);
        _sequence.SetLoops(-1, LoopType.Restart);
    }

    public void StartMove()
    {
        SetSequence();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer ==LayerMask.NameToLayer("Player"))
        {
            OnHit?.Invoke();
        }
    }
}