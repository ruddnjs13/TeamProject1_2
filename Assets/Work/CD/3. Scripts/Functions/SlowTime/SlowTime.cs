using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
public class SlowTime : MonoBehaviour
{
    [SerializeField] private float _duration;
    
    public UnityEvent OnUse;

    [SerializeField] private bool _isUse;
    
    private Coroutine _myCoroutine;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isUse) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnUse?.Invoke();
            _myCoroutine = StartCoroutine(SkillDuration());
        }

    }

    private IEnumerator SkillDuration()
    {
        _isUse = true;
        
        yield return new WaitForSeconds(_duration);

        DestroyItem();
    }
        
    private void DestroyItem()
    {
        this._isUse = false;
        this.gameObject.SetActive(false);
    }
}