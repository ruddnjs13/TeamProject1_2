using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float _reBirthTime = 2f;
    [SerializeField] private GameObject _rotateAxis;
    

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
