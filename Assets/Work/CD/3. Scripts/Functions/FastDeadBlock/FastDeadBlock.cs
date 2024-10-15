using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastDeadBlock : MonoBehaviour
{
    [SerializeField] private Vector2 _movePosition;
    [Range(0, 1)] [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _target;

    private Vector2 _previousObjPosition;
    private Vector2 _previousObjMovePosition;

    private void Start()
    {
        _previousObjPosition = transform.position;
        _previousObjMovePosition = _movePosition;
    }

    private void Update()
    {
        MoveLerp();
    }

    private void MoveLerp()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, _movePosition.y), _moveSpeed);

        if (Mathf.Round(transform.position.y) <= _previousObjMovePosition.y)
        {
            _movePosition = _previousObjPosition;
            _moveSpeed = 0.005f;
        }
        else if (Mathf.Ceil(transform.position.y) >= _previousObjPosition.y)
        {
            _movePosition.y = _previousObjMovePosition.y;
            _moveSpeed = 0.08f;
        }
        else
        {
            Debug.Log($"Transform{transform.position.y}\n movePosition{_movePosition.y}");
        }
    }
}
