using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TargetLaser : MonoBehaviour
{
    [SerializeField] private float _laserWidth;

    [SerializeField] private float _laserCool;
    [SerializeField] private float _laserSpeed;

    [SerializeField] private Transform _target;

    [Range(0, 1f)] [SerializeField] private float _rotateSpeed;

    private LineRenderer _lineRenderer;

    private Sequence _laserSequence;
    
    private Tweener _laserTween;

    private Vector3 _dir;

    private RaycastHit2D _hit;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    
    private void Start()
    {
        Shoot();
        TestDotLaser();
    }

    private void Shoot()
    {
        _lineRenderer.SetPosition(0, transform.position);
    } 

    private void Update()
    {
        TargetRotateObj();
    }

    private void FixedUpdate()
    {
        TargetRay();
    }

    private IEnumerator DelayLaser()
    {
        yield return new WaitForSeconds(_laserCool);
        Debug.Log("Laser");
        _lineRenderer.widthMultiplier = 100f;
        // _lineRenderer.widthMultiplier = Mathf.Lerp(_lineRenderer.widthMultiplier, _laserWidth, _laserSpeed);
        yield return new WaitForSeconds(_laserCool);
        _lineRenderer.widthMultiplier = 0f;
        // _lineRenderer.widthMultiplier = Mathf.Lerp(_laserWidth, 0f, _laserSpeed);
    }

    private void TargetRay()
    {
        _hit = Physics2D.Raycast(transform.position, _dir);

        if (_hit)
        {
            _lineRenderer.SetPosition(1, _hit.point);
            TestDotLaser();
        }
    }

    private void TestDotLaser()
    {
        _laserTween = DOTween.To(() => _lineRenderer.widthMultiplier, x => _lineRenderer.widthMultiplier = x, _laserWidth, _laserSpeed);
        // _laserTween = DOVirtual.Float(0.1f, _laserWidth, _laserSpeed, x => Debug.Log(x));
        _laserSequence = DOTween.Sequence();
        _laserSequence.AppendInterval(_laserCool / 2);
        _laserSequence.Append(_laserTween); // 두께가 굵어 지는거.
        _laserSequence.AppendInterval(_laserCool / 2);
        _laserSequence.SetLoops(2, LoopType.Yoyo);
    }


    public void TargetRotateObj()
    {
        _dir = _target.position - transform.position;

        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), _rotateSpeed);
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(transform.position, _hit.point - (Vector2)transform.position);
    }

#endif
}