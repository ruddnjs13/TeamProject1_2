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
        if(ActiveObj as ISwitchble == null)
        {
            Debug.LogError("This Object is not succession ISwitchble. Put in ISwitchble Obj");
        }
    }
    private void Awake()
    {
        active = ActiveObj as ISwitchble;
    }
    public void ExecutionEvent()
    {
        active.SwitchOnoff(true);
    }
    
}
