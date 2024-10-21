using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TargetLaser : MonoBehaviour
{
    [SerializeField] private float _rotationCool;
    [SerializeField] private float _rotationDuration;

    [SerializeField] private float _size;
    [SerializeField] LayerMask _whatIsPlayer;

    [SerializeField] private Transform _target;

    [Range(0, 1f)] [SerializeField] private float _rotateSpeed;
    
    private Vector3 _dir;

    private RaycastHit2D _ray;

    private Collider2D _collider;
    private LineRenderer _line;

    private Sequence _sequence;

    private bool _isFirst;

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
            _isFirst = false;
            _sequence.Kill();
            Debug.Log("아");
            if (!_line.enabled) _line.enabled = true;
            TargetRotateObj(_collider.transform);
        }
        else
        {
            if (!_isFirst)
                DefaultAngle();
            DefaultRotate();
        }
    }

    private void DefaultAngle()
    {
        _isFirst = true;
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), _rotateSpeed);
    }

    private void DefaultRotate()
    {
        if (!_sequence.IsActive())
            DefaultTween();
    }

    private void DefaultTween()
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendInterval(_rotationCool)
            .Append(transform.DORotate(new Vector3(0, 0, -180), _rotationDuration, RotateMode.Fast).SetRelative())
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
        if (!target) return;

        _dir = target.position - transform.position;

        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, angle), _rotateSpeed);
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