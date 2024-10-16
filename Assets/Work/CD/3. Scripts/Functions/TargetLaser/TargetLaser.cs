using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TargetLaser : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    [Range(0, 1f)] [SerializeField] private float _rotateSpeed;
    
    private LineRenderer _lineRenderer;

    private Vector3 _dir;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        Shoot();
    }

    private void Shoot()
    {
        _lineRenderer.SetPosition(0, transform.position);
    }

    private void Update()
    {
        TargetRotateObj();
        _lineRenderer.SetPosition(1, _target.position);
    }


    public void TargetRotateObj()
    {
        _dir = _target.position - transform.position;
        
        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), _rotateSpeed);
    }
}
