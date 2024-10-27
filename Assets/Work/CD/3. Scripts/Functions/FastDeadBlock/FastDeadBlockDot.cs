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
    [SerializeField] private float _delayUpSecond, _delayDownSecond;
    
    public float _duration;
    private float _previousPosition;

    private Tween _tween, _tween2;
    
    private Sequence _sequence;
    
    public void Start()
    {
        _previousPosition = transform.position.y;
        SetSequence();
    }

    
    public void SetSequence()
    {
        _tween = transform.DOMove(new Vector2(transform.position.x, _position), _duration).SetEase(Ease.OutQuart);
        _tween2 = transform.DOMove(new Vector2(transform.position.x, _previousPosition), _duration).SetEase(Ease.InQuart);

        _sequence = DOTween.Sequence();
        _sequence.AppendInterval(_delayUpSecond);
        _sequence.Append(_tween);
        _sequence.AppendInterval(_delayDownSecond);
        _sequence.Append(_tween2);
        _sequence.OnComplete(() => _sequence.Restart());
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer ==LayerMask.NameToLayer("Player"))
        {
            OnHit?.Invoke();
        }
    }
}