using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSensor : MonoBehaviour
{
    public UnityEvent Active;

    public void ExecutionEvent()
    {
        Active?.Invoke();
    }
}
