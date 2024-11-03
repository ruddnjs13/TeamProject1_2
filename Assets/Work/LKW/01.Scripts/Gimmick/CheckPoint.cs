using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour,IInteractable
{
    public int rotateIdx = 0;

    private void Awake()
    {
        rotateIdx = (int)transform.rotation.eulerAngles.z / 90;
    }

    public void StartInteract()
    {
        
    }

    public void Interact()
    {
        GameManager.Instance.EnableCheckPoint(this);
    }

    public void EndInteract()
    {
    }
}
