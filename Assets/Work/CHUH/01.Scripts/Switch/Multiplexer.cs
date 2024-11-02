using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Multiplexer : MonoBehaviour, ISwitchable
{
    [SerializeField] private int maxActiveCount;
    [SerializeField] private int nowActiveCount;
    public UnityEvent ActiveObj;
    public void Activate()
    {
        nowActiveCount++;
        if(nowActiveCount >= maxActiveCount)
        {
            ActiveObj?.Invoke();
        }
    }

    public void Deactivate()
    {
        nowActiveCount--;
    }
}
