using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


public class TargetLaser : MonoBehaviour
{
    public UnityEvent OnHitEvent;
    
    [Header("Rotation Settings")]
    [SerializeField] private bool _isFirst = true;
    [SerializeField] private bool _rotationEnable = true;
    [Space(10)] [SerializeField] private float _defaultRotateDeley;
    [SerializeField] private float _rotationCool;
    [SerializeField] private float _rotationDuration;
    [Header("Laser Settings")] [SerializeField]
    private float _laserStartValue;

    [SerializeField] private float _laserEndValue;
    [SerializeField] private float _laserDuration;
    [SerializeField] private float _fireLaserDeley;

    [Header("OverlapSize Settings")] [SerializeField]
    private float _size;

    [SerializeField] LayerMask _whatIsPlayer;

    [SerializeField] private Transform _target;

    [Range(0, 1f)] [SerializeField] private float _rotateSpeed;

    private Vector3 _dir;

    private RaycastHit2D _ray;

    private Collider2D _collider;
    private LineRenderer _line;

    private Tween _laserTween;

    private Sequence _sequence;
    private Sequence _defaultTween;
    private Sequence _laserSequence;


    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.SetPosition(0, transform.position);
    }

    private void Update()
    {
        ShootRay();
        TargetFind();
    }

    public void TargetFind()
    {
        _collider = Physics2D.OverlapCircle(transform.position, _size, _whatIsPlayer);

        if (_collider != null)
        {
            if (_isFirst) _isFirst = false;
            _defaultTween.Kill();
            _sequence.Kill();
            if (_defaultTween.IsActive()) _defaultTween.Kill();
            Debug.Log("아");
            if (!_line.enabled) _line.enabled = true;
            TargetRotateObj(_collider.transform);
        }
        else
        {
            if (_laserSequence.IsActive())
            {
                if (!_laserSequence.IsComplete()) return;
            }
            if (!_isFirst)
            {
                DefaultAngle();
            }
            else
            {
                _isFirst = true;
                DefaultRotate();
            }
        }
    }

    private void DefaultAngle()
    {
        // _isFirst = true;
        DefaultZeroRotate();
    }

    private void DefaultZeroRotate()
    {
        if (_defaultTween.IsActive()) return;

        Debug.Log("기본값");
        _defaultTween = DOTween.Sequence();
        _defaultTween.Append(transform.DORotate(Vector3.zero, _rotationDuration, RotateMode.Fast)
            .OnComplete(() => _isFirst = true));
    }

    private void DefaultRotate()
    {
        if (!_sequence.IsActive())
        {
            Debug.Log("핫!");
            DefaultTween();
        }
    }

    private void DefaultTween()
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendInterval(_rotationCool)
            .Append(transform.DORotate(new Vector3(0, 0, -180), _rotationDuration, RotateMode.WorldAxisAdd))
            .AppendInterval(_rotationCool)
            .SetLoops(2, LoopType.Yoyo);
    }

    private void ShootRay()
    {
        _ray = Physics2D.Raycast(transform.position, transform.right);

        if (_ray)
        {
            _line.SetPosition(1, _ray.point);
        }
    }

    private void TargetRotateObj(Transform target = null)
    {
        if (!target || !_rotationEnable) return;

        _dir = target.position - transform.position;

        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, angle), _rotateSpeed);

        OnFireLaser();
    }

    private void OnFireLaser()
    {
        Debug.Log("트윈!");
        
        if (!_laserTween.IsActive())
        {
            _laserTween = DOTween.To(() => _laserStartValue, x => _line.widthMultiplier = x, _laserEndValue, _laserDuration);
            _laserTween.Pause();
        }

        if (_laserSequence.IsActive()) return;
        _laserSequence = DOTween.Sequence();
        _laserSequence.AppendInterval(_fireLaserDeley)
            .Append(_laserTween. OnStart(() => _rotationEnable = false))
            .AppendInterval(_fireLaserDeley)
            .SetLoops(2, LoopType.Yoyo);
        
        _laserSequence.OnComplete(() =>
        {
            _rotationEnable = true;
            OnHitEvent?.Invoke();
            _laserTween.Kill();
        });
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, _size);
        Gizmos.color = Color.white;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.right);
    }

#endif
}