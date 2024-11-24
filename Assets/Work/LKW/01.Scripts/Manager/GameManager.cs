using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float _reBirthTime = 2f;
    [SerializeField] private GameObject _rotateAxis;
    [SerializeField] private GameObject _escPanel;
    [SerializeField] private InputReaderSO _inputReaderSO;

    public UnityEvent DeadEvent;

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

    private void Start()
    {
        _inputReaderSO.RockInput(false);
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

    [Header("Map Index")]
    [SerializeField] private int _nextMapIndex;

    public void NextSceneLoad()
    {
        SceneManager.LoadScene(_nextMapIndex);
    }


    public void PlayerDead(Player player)
    {
        StartCoroutine(PlayerDeadCoroutine(player));
        DeadEvent?.Invoke();
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
