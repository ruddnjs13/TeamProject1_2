using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    [SerializeField] private float _size;
    [SerializeField] LayerMask _whatIsPlayer;
    
    private LineRenderer _line;
    private Collider2D _collider;
    private RaycastHit2D _ray;
    
    
    public Transform _target;
    
    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.SetPosition(0, transform.position);
    }

    private void Update()
    {
        TargetFind();
    }

    public void TargetFind()
    {
        _collider = Physics2D.OverlapCircle(transform.position, _size, _whatIsPlayer);

        if (_collider != null)
        {
            Debug.Log("아");
            TargetRay(_collider.transform);
        }
    }

    private void TargetRay(Transform target = null)
    {
        if (!target) return;
        float _dir = Vector3.Distance(transform.position, target.position);
        _ray = Physics2D.Raycast(transform.position, target.position);

        if (_ray)
        {
            _line.SetPosition(1, _ray.point);
        }
    }
    
    #if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(transform.position, _size);
    }

#endif
}
