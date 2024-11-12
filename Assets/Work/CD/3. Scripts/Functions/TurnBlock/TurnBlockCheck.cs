using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnBlockCheck : MonoBehaviour, IInteractable
{
    public UnityEvent OnCheck;
    public void Interact()
    {
        OnCheck?.Invoke();
    }

    public void EndInteract()
    {
    }
}
