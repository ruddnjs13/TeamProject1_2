using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    #region  Compo Region
    protected Rigidbody2D RbCompo { get; private set; }
    protected Collider2D ColliderCompo { get; private set; }

    #endregion


    #region Movement Region


    public void SetMovement(Vector2 movement)
    {
        RbCompo.velocity = movement;
    }

    public void StopImmediately(bool isStop = false)
    {
        if (isStop)
        {
            RbCompo.velocity = Vector3.zero;
        }
    }

    #endregion
}
