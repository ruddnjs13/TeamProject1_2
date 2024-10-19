using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TargetLaser : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPlayer;
    
    [SerializeField] private float _overlapSize;
    

    [SerializeField] private Transform _target;

    [Range(0, 1f)] [SerializeField] private float _rotateSpeed;

    private Vector3 _dir;

    private RaycastHit2D _hit;

    private Collider2D _collider;

    private void Update()
    {
        TargetRotateObj();
    }

    private void FixedUpdate()
    {
        TargetFind();
    }

    private void TargetFind()
    {
        _collider = Physics2D.OverlapCircle(transform.position, _overlapSize, _whatIsPlayer);
    }


    private void TargetRotateObj()
    {
        _dir = _target.position - transform.position;

        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), _rotateSpeed);
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _hit.point - (Vector2)transform.position);
        Gizmos.color = Color.white;
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _overlapSize);
        Gizmos.color = Color.white;
    }

#endif
}