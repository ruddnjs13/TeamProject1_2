using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, Controls.IPlayerActions
{
    private Controls _controls;

    [HideInInspector] public bool _isDashing = false;

    public Action JumpEvent;
    public Action InteractionEvent;
    public Action ClockwiseRotateEvent;
    public Action CounterClockwiseRotateEvent;
    public event Action<Vector2> OnMoveEvent;
    
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
    

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(Movement);
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
}
