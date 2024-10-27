using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour,IInteractable
{
    public void StartInteract()
    {
        
    }

    public void Interact()
    {
        GameManager.instance.EnableCheckPoint(this);
    }

    public void EndInteract()
    {
    }
}
