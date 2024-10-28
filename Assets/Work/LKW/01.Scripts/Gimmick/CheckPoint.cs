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
        GameManager.Instance.EnableCheckPoint(this);
    }

    public void EndInteract()
    {
    }
}
