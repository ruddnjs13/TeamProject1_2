using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    private Player _owner;

    public void Initialize(Player owner)
    {
        _owner = owner;
    }

    protected virtual void OnSkill()
    {
        
    }
}
