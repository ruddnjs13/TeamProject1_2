using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, Controls.IPlayerActions
{
    private Controls _controls;

    public Action JumpEvnet;
    
    public float XMove { get; private set; }
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
        XMove = context.ReadValue<Vector2>().x;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpEvnet?.Invoke();
        }
    }
}
