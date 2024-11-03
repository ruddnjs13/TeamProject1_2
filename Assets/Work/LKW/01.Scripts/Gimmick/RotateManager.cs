using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class RotateManager : MonoSingleton<RotateManager>
{
    
    public UnityEvent StartRotateEvent;
    public UnityEvent EndRotateEvent;
    
    
    [SerializeField] private RotateMap1[] _rotateMap1s;
    [SerializeField] private RotateMap2[] _rotateMap2s;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private Transform _rotateAxis;
    [SerializeField] private GameObject _grid;
    [SerializeField] private float _rotateTime1;
    [SerializeField] private float _rotateTime2;
    private Player _player;

    public float[] _rotations1 = { 0,90,180,270 };

    public int CurrentRotationIdx { get; set; } = 0;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        InitializeRotateMaps();
    }

    private void OnEnable()
    {
        StartRotateEvent.AddListener(()=> _player.playerInput.RockInput(true));
        StartRotateEvent.AddListener(()=> _player.StopImmediately());
        EndRotateEvent.AddListener(()=> _player.playerInput.RockInput(false));
    }

    private void OnDisable()
    {
        InitializeRotateMaps();StartRotateEvent.RemoveListener(()=> _player.playerInput.RockInput(true));
        StartRotateEvent.RemoveListener(()=> _player.StopImmediately());
        EndRotateEvent.RemoveListener(()=> _player.playerInput.RockInput(false));
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
