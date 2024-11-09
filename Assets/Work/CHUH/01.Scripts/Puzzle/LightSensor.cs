using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSensor : MonoBehaviour
{
    public MonoBehaviour ActiveObj;
    private ISwitchable active;
    private void OnValidate()
    {
        if (ActiveObj !=null && ActiveObj as ISwitchable == null)
        {
            ActiveObj = null;
            Debug.LogWarning("This Object is not succession ISwitchble. Put in ISwitchble Obj");
        }
    }
    private void Awake()
    {
        try
        {
            active = (ISwitchable)ActiveObj;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"ActiveObj is not succession ISwitchble. Message : {ex}");
        }
    }
    public void ExecutionEvent()
    {
        active?.Activate();
    }

}