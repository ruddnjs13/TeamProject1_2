using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    #region  Compo Region
    public Rigidbody2D RbCompo { get;  set; }
    public Collider2D ColliderCompo { get;  set; }
    public Animator AnimatorCompo { get; set; }
    #endregion

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private Transform _boxTrm;
    
    public NotifyValue<bool> IsGround { get; private set; }

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

    #region GroundCheck

    public void CheckGround()
    {
        if (Physics2D.OverlapBox(_boxTrm.position, _boxSize, 0f, _whatIsGround))
        {
            IsGround.Value = true;
        }
        else
        {
            IsGround.Value = false;
        }
    }
    #endregion
}
