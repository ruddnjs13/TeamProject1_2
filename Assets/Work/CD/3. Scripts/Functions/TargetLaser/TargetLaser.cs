using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


public class TargetLaser : MonoBehaviour
{
    public UnityEvent OnHitEvent;

    [Header("Rotation Settings")] [SerializeField]
    private bool _isFirst = true;

    [SerializeField] private bool _rotationEnable = true;
    [Space(10)] [SerializeField] private float _defaultRotateDeley;
    [SerializeField] private float _rotationCool;
    [SerializeField] private float _rotationDuration;

    [Header("Laser Settings")] [SerializeField]
    private float _laserStartValue;

    [SerializeField] private float _laserRange;

    [SerializeField] private float _laserEndValue;
    [SerializeField] private float _laserDuration;
    [SerializeField] private float _fireStartLaserDeley;

    [Header("Overlap And Raycast Settings")] [Space(10)] [SerializeField]
    private LayerMask _rayLayer;

    [SerializeField] private float _size;
    [SerializeField] LayerMask _whatIsPlayer;
    [SerializeField] private Transform _rangeTarget;
    [SerializeField] private Transform _checkTarget;
    [Range(0, 1f)] [SerializeField] private float _rotateSpeed;

    private Vector3 _dir;

    private RaycastHit2D[] _ray = new RaycastHit2D[10];

    private Collider2D _collider;
    private LineRenderer _line;

    private Tween _laserTween;

    private Sequence _sequence;
    private Sequence _defaultTween;
    private Sequence _laserSequence;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.SetPosition(0, transform.localPosition);
    }

    private void OnEnable()
    {
        _rangeTarget.localScale = new Vector3(_size * 2, _size * 2, 1);
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
            .Append(transform.DORotate(new Vector3(0, 0, -180), _rotationDuration))
            .AppendInterval(_rotationCool)
            .SetLoops(2, LoopType.Yoyo);
    }

    private void ShootRay()
    {
        int filterRay = Physics2D.RaycastNonAlloc(transform.position, transform.right, _ray, _laserRange, _rayLayer);

        if (filterRay > 0)
        {
            // 이부분 보안 좀 필요함 (FSM 리펙토링 후 수정)
            _line.SetPosition(1,
                _ray.FirstOrDefault(a => a.collider.gameObject).collider.gameObject.layer !=
                LayerMask.NameToLayer("Player")
                    ? _ray.FirstOrDefault(a => a.collider.gameObject).point
                    : _ray[1].point
            );
        }
    }

    private void TargetRotateObj(Transform target = null)
    {
        if (!target) return;
        if (!_rotationEnable) return;

        _dir = target.position - transform.position;

        float angle = transform.parent.transform.parent.transform.parent.transform.parent.rotation.eulerAngles.z >= 180 ? Mathf.Atan2(-_dir.y, -_dir.x) * Mathf.Rad2Deg : Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, angle), _rotateSpeed);

        GameObject obj = _ray.First().collider.gameObject;
        if (obj.layer == LayerMask.NameToLayer("Player") && !_laserSequence.IsActive()) OnFireLaser();
    }

    private void OnFireLaser()
    {
        Debug.Log("트윈!");

        if (!_laserTween.IsActive())
        {
            _laserTween = DOTween.To(() => _laserStartValue, x => _line.widthMultiplier = x, _laserEndValue,
                _laserDuration);
            // _laserTween.Pause();
        }

        if (_laserSequence.IsActive()) return;

        _laserSequence = DOTween.Sequence();
        _laserSequence.PrependInterval(_fireStartLaserDeley / 2)
            .AppendCallback( () => _rotationEnable = false)
            .AppendInterval(_fireStartLaserDeley / 2)
            .Append(_laserTween).OnComplete(() =>
            {
                if (_ray.First().collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    OnHitEvent?.Invoke();
                }
            })
            .SetLoops(2, LoopType.Yoyo);
        _laserSequence.OnComplete(() =>
        {
            _rotationEnable = true;
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
        Gizmos.DrawRay(transform.position, transform.right * _laserRange);
    }

#endif
}