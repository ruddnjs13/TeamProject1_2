using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    #region  Compo Region
    protected Rigidbody2D RbCompo { get;  set; }
    protected Collider2D ColliderCompo { get;  set; }
    protected InputReaderSO InputCompo { get;  set; }
    #endregion

    #region Movement Region


    public void SetMovement(Vector2 movement)
    {
        RbCompo.velocity = movement;
    }

    public void StopImmediately(bool isYStop = false)
    {
        float xMove = 0f;
        if (isYStop)
        {
            RbCompo.velocity = Vector3.zero;
        }
        else
        {
            RbCompo.velocity = new Vector2(xMove, RbCompo.velocity.y);
        }
    }
    #endregion
}
