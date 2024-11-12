using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnBlockGroup : MonoBehaviour
{
    [SerializeField] private List<TurnBlock> _turnBlockGroup;
    
    public UnityEvent OnCorrect;
    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        _turnBlockGroup.ForEach(block => block.Initialize());
    }

    public void CorrectCheck()
    {
        if (Check() == true)
            OnCorrect?.Invoke();

    }

    private bool Check()
    {
        foreach (TurnBlock block in _turnBlockGroup)
        {
            if (block.IsCorrect == false) return false;
        }

        return true;
    }
}
