using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneFade : MonoBehaviour
{
    public UnityEvent SceneFadeEvent;
    private void Start()
    {
        SceneFadeEvent?.Invoke();
    }
}
