using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Keymaping : MonoBehaviour
{
    private Controls _contorls;

    private void OnEnable()
    {
        if (_contorls == null)
        {
            _contorls = new Controls();
        }
    }

    public void WKey()
    {
        _contorls.Player.Movement.PerformInteractiveRebinding(0)
            .WithControlsExcluding("Mouse")
            .WithCancelingThrough("<keyboard>/escape")
            .OnComplete(op =>
            {
                Debug.Log("키 변경 성공!");
            })
            .OnCancel(op =>
            {
                op.Dispose();
                Debug.Log("키 변경 실패!");
            })
            .Start();
    }

    public void Jump()
    {
        
    }

    public void Interaction()
    {
        
    }
}
