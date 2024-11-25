using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float _reBirthTime = 4f;
    [SerializeField] private GameObject _rotateAxis;
    [SerializeField] private GameObject _escPanel;
    [SerializeField] private InputReaderSO _inputReaderSO;
    private ParticleSystem _deadParticle;

    public UnityEvent DeadEvent;
    public UnityEvent EndDeadEvent;

    private bool _uiMode = false;

    public void UiRock()
    {
        _inputReaderSO.UIRockInput(true);
    }
    public void UiUnRock()
    {
        _inputReaderSO.UIRockInput(false);
    }

    
    public GameObject RotateAxis
    {
        get => _rotateAxis;
        set => _rotateAxis = value;
    }

    private void Awake()
    {
        _deadParticle = GetComponentInChildren<ParticleSystem>();
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
        _inputReaderSO.UIRockInput(false);
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
        player.transform.Find("Visual").gameObject.SetActive(false);
        _deadParticle.transform.position = player.transform.position;
        _deadParticle.Play();
        yield return new WaitForSeconds(0.3f);
        _deadParticle.Simulate(0);
        yield return new WaitForSeconds(_reBirthTime);
        EndDeadEvent?.Invoke();
        yield return new WaitForSeconds(_reBirthTime/10);
        ReSpawnAndSetPos(player);
    }

    private void ReSpawnAndSetPos(Player player)
    {
        _rotateAxis.transform.rotation = currentCheckpoint.transform.localRotation;
        RotateManager.Instance.CurrentRotationIdx = currentCheckpoint.rotateIdx;
        player.transform.rotation = currentCheckpoint.transform.rotation;
        player.transform.position = currentCheckpoint.transform.position;
        player.transform.Find("Visual").gameObject.SetActive(true);
        player.StateMachine.ChangeState(PlayerStateEnum.Idle);
    }
}
