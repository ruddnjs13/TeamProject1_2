using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateManager : MonoSingleton<RotateManager>
{
    public Action MapRotateEvent;
    
    [SerializeField] private RotateMap1[] _rotateMap1s;
    [SerializeField] private RotateMap2[] _rotateMap2s;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private Transform _rotateAxis;
    [SerializeField] private GameObject _grid;
    [SerializeField] private float _rotateTime1;
    [SerializeField] private float _rotateTime2;

    public float[] _rotations1 = { 0,90,180,270 };

    public int CurrentRotationIdx { get; set; } = 0;

    private void Awake()
    {
        InitializeRotateMaps();
    }

    private void InitializeRotateMaps()
    {
        foreach (RotateMap1 item in _rotateMap1s)
        {
            item.Initialize(_playerTrm,_rotateAxis,_grid,_rotateTime1);
        }

        foreach (RotateMap2 item in _rotateMap2s)
        {
            item.Initialize(_playerTrm,_rotateAxis,_grid,_rotateTime2);
        }
    }
    
    
}
