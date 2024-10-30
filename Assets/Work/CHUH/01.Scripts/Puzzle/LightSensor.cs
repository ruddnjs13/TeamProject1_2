using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSensor : MonoBehaviour
{
    [SerializeField] private MonoBehaviour ActiveObj;
    private ISwitchble active;
    private void OnValidate()
    {
        if (ActiveObj !=null && ActiveObj as ISwitchble == null)
        {
            ActiveObj = null;
            Debug.LogWarning("This Object is not succession ISwitchble. Put in ISwitchble Obj");
        }
    }
    private void Awake()
    {
        try
        {
            active = (ISwitchble)ActiveObj;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"ActiveObj is not succession ISwitchble. Message : {ex}");
        }
    }
    public void ExecutionEvent()
    {
        active.SwitchOnoff(true);
    }

}