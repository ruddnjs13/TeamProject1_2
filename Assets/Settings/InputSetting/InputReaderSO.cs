using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, Controls.IPlayerActions,Controls.IUIActions
{
    private Controls _controls;


    public Action JumpEvent;
    public Action InteractionEvent;
    public Action ClockwiseRotateEvent;
    public Action CounterClockwiseRotateEvent;
    public Action EscEvent;
    
    public event Action<Vector2> OnMoveEvent;
    
    public Vector2 Movement { get; private set; }
    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
            _controls.UI.SetCallbacks(this);
        }
        
        _controls.Player.Enable();
        _controls.UI.Enable();

    }

    public void RebindInputReader(string rebindInfo)
    {
        _controls.LoadBindingOverridesFromJson(rebindInfo);
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
    public void UIRockInput(bool isRock)
    {
        if (isRock)
        {
            Movement = Vector3.zero;
            _controls.UI.Disable();
        }
        else
        {
            _controls.UI.Enable();
        }
    }
    

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(Movement);
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
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

    public void OnMapRotateCounterClockwise(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CounterClockwiseRotateEvent?.Invoke();
        }
    }

    public void OnMapRotateClockwise(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ClockwiseRotateEvent?.Invoke();
        }
    }

    public void OnEscMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            EscEvent?.Invoke();
        }
    }
}
