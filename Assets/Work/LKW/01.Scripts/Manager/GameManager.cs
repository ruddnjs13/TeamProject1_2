using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float _reBirthTime = 2f;
    [SerializeField] private GameObject _rotateAxis;
    [SerializeField] private GameObject _escPanel;
    [SerializeField] private InputReaderSO _inputReaderSO;
    
    private bool _uiMode = false;
    public GameObject RotateAxis
    {
        get => _rotateAxis;
        set => _rotateAxis = value;
    }

    private void OnEnable()
    {
        _inputReaderSO.EscEvent += HandleEscEvent;
    }

    public void OnDisable()
    {
        _inputReaderSO.EscEvent -= HandleEscEvent;
    }

    public void HandleEscEvent()
    {
        if (!_uiMode)
        {
            _uiMode = true;
            _escPanel.SetActive(true);
            _inputReaderSO.RockInput(true);
            Time.timeScale = 0f;
        }
        else
        {
            _uiMode = false;
            _escPanel.SetActive(false);
            _inputReaderSO.RockInput(false);
            Time.timeScale = 1f;
        }
    }


    public CheckPoint currentCheckpoint;


    public void EnableCheckPoint(CheckPoint newCheckPoint)
    {
        currentCheckpoint = newCheckPoint;
    }


    public void PlayerDead(Player player)
    {
        StartCoroutine(PlayerDeadCoroutine(player));
    }

    private IEnumerator PlayerDeadCoroutine(Player player)
    {
        yield return new WaitForSeconds(_reBirthTime);
        _rotateAxis.transform.rotation = currentCheckpoint.transform.localRotation;
        RotateManager.Instance.CurrentRotationIdx = currentCheckpoint.rotateIdx;
        player.transform.rotation = currentCheckpoint.transform.rotation;
        player.transform.position = currentCheckpoint.transform.position;
        player.StateMachine.ChangeState(PlayerStateEnum.Idle);
    }
    
    
}
