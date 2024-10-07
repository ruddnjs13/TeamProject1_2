using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
public class SlowTime : MonoBehaviour
{
    public UnityEvent OnTimeSlowPlay;
    public UnityEvent OnTimeSlowStop;

    private void Update()
    {
        InputSet();
    }

    private void InputSet()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnTimeSlowPlay?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            OnTimeSlowStop?.Invoke();
        }
        else
        {
            return;
        }
    }
}