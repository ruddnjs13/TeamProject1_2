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
    }
    
}
