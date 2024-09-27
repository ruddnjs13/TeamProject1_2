using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public Player _owner;

    public void Initialize(Player owner)
    {
        _owner = owner;
    }
}
