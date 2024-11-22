using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyMapping : MonoSingleton<KeyMapping>
{
    private Controls _controls;
    public String RebindInfo {get; private set;}
    [SerializeField] private InputReaderSO _inputReaderSO;
    [SerializeField] private List<TextMeshProUGUI> _moveKeyBindingTexts;
    [SerializeField] private TextMeshProUGUI _jumpKeyBindingTexts;
    [SerializeField] private TextMeshProUGUI _interactKeyBindingTexts;
    
    private bool _isRebinding = false;
    

    private void Awake()
    {
        InitInputSetting();
    }

    private void InitInputSetting()
    {
        _controls = new Controls();
        _controls.Player.Enable();
        _moveKeyBindingTexts[0].text = _controls.Player.Movement.GetBindingDisplayString(4);
        _moveKeyBindingTexts[1].text = _controls.Player.Movement.GetBindingDisplayString(3);

        
        _controls.LoadBindingOverridesFromJson(RebindInfo);
        _jumpKeyBindingTexts.text = _controls.Player.Jump.GetBindingDisplayString(0);
        _interactKeyBindingTexts.text = _controls.Player.Interaction.GetBindingDisplayString(0);               

    }

    public void MovementRebinding(int bindIdx)
    {
        if(_isRebinding) return;
        _isRebinding = true;
        _moveKeyBindingTexts[4-bindIdx].text = "New Key";
        _controls.Player.Disable();

        _controls.Player.Movement.PerformInteractiveRebinding(bindIdx)
            .WithControlsExcluding("Mouse")
            .OnComplete( op =>
            {
                RebindInfo = _controls.SaveBindingOverridesAsJson();
                _controls.LoadBindingOverridesFromJson(RebindInfo);
                 _moveKeyBindingTexts[4-bindIdx].text =  _controls.Player.Movement.GetBindingDisplayString(bindIdx);
                 _inputReaderSO.RebindInputReader(RebindInfo);
                 Debug.Log(RebindInfo);
                 _isRebinding = false;
            })
            .OnCancel(op =>
            {
                op.Dispose();
                _isRebinding = false;
            }).Start();
        _controls.Player.Enable();

    }
    public void JumpRebinding()
    {
        if(_isRebinding) return;
        _isRebinding = true;
        
        _jumpKeyBindingTexts.text = "New Key";
        _controls.Player.Disable();

        _controls.Player.Jump.PerformInteractiveRebinding(0)
            .WithControlsExcluding("Mouse")
            .OnComplete( op =>
            {
                RebindInfo = _controls.SaveBindingOverridesAsJson();
                _controls.LoadBindingOverridesFromJson(RebindInfo);
                _jumpKeyBindingTexts.text =  _controls.Player.Jump.GetBindingDisplayString();
                _isRebinding = false;
                _inputReaderSO.RebindInputReader(RebindInfo);
            })
            .Start()
            .OnCancel(op =>
            {
                op.Dispose();
                _isRebinding = false;
            }).Start();
        _controls.Player.Enable();
    } 
    public void InteractRebinding()
    {
        if(_isRebinding) return;
        _isRebinding = true;
        
        _interactKeyBindingTexts.text = "New Key";
        _controls.Player.Disable();

        _controls.Player.Interaction.PerformInteractiveRebinding(0)
            .WithControlsExcluding("Mouse")
            .OnComplete( op =>
            {
                RebindInfo = _controls.SaveBindingOverridesAsJson();
                _controls.LoadBindingOverridesFromJson(RebindInfo);
                _interactKeyBindingTexts.text =  _controls.Player.Interaction.GetBindingDisplayString();
                _isRebinding = false;
                _inputReaderSO.RebindInputReader(RebindInfo);
            })
            .OnCancel(op =>
            {
                op.Dispose();
                _isRebinding = false;
            }).Start();
        _controls.Player.Enable();
    }
}