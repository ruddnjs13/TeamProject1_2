using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _reBirthTime = 2f;
    [SerializeField] private GameObject _rotateAxis;
    
    public static GameManager instance;

    public CheckPoint currentCheckpoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        player.transform.rotation = currentCheckpoint.transform.rotation;
        player.transform.position = currentCheckpoint.transform.position;
        player.StateMachine.ChangeState(PlayerStateEnum.Idle);
    }
}
