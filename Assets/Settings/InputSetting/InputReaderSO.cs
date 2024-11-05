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

    [HideInInspector] public bool _isDashing = false;

    public Action JumpEvent;
    public Action DashEvent;
    public Action InteractionEvent;
    
    public Vector2 Movement { get; private set; }
    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
        }
        
        _controls.Player.Enable();

    }

    public void RockInput(bool isRock)
    {
        if (isRock)
        {
            Movement = Vector3.zero;
            _controls.Player.Disable();
        }
        else
        {
            _controls.Player.Enable();
        }
    }
    

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isDashing = true;
            DashEvent?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("점프");
            JumpEvent?.Invoke();
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InteractionEvent?.Invoke();
        }
    }
}
