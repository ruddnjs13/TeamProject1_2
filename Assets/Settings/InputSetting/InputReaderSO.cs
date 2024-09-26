using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, Controls.IPlayerActions
{
    private Controls _controls;
    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
        }
        
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
    }

    public void OnDash(InputAction.CallbackContext context)
    {
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
    }
}
