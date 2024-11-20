using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class CheckPoint : MonoBehaviour,IInteractable
{
    public UnityEvent OnEnableEvent;
    public int rotateIdx = 0;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Light2D _spotLight;
    
    private SpriteRenderer _spriteRenderer;

    public bool isActive { get; private set; } = false;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rotateIdx = (int)transform.rotation.eulerAngles.z / 90;
    }

    public void Interact()
    {
        if (isActive) return;
        GameManager.Instance.EnableCheckPoint(this);
        _spriteRenderer.sprite = _onSprite;
        _spotLight.gameObject.SetActive(true);
        OnEnableEvent.Invoke();
        isActive = true;
    }

    public void EndInteract()
    {
    }
}
