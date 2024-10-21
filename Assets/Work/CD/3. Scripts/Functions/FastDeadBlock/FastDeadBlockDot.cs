    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class FastDeadBlockDot : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void asdfjlksda()
    {
        Debug.Log("ㄴㅇㅁ러ㅣㅏㅁㄴ어리ㅏㄴㅁㅇㄹ ");
    }
    
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
}