using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Agent : MonoBehaviour
{
    #region  Compo Region
    public Rigidbody2D RbCompo { get; protected set; }
    public Collider2D ColliderCompo { get; protected set; }
    public Animator AnimatorCompo { get; protected set; }
    #endregion
    
    #region CheckGroundSetting
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private Transform _boxTrm;
    #endregion

    #region WallCheckerSetting

    [SerializeField] private LayerMask _whatIsWall;
    [SerializeField] private Transform _checkerTrm;
    [SerializeField] private float _distance;

    #endregion

    [SerializeField]
    public NotifyValue<bool> IsGround = new NotifyValue<bool>();
    public float facingDirection { get; protected set; }

    public bool canFlip = true;
    
    protected virtual void Awake()
    {
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();
        RbCompo = GetComponent<Rigidbody2D>();
    }
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

    #region CheckGroundRegion
    protected void CheckGround()
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

    #region WallCheckRegion

    public bool CheckWall(float direction)
    {
        return (Physics2D.Raycast(_checkerTrm.position,
            new Vector2(direction, 0), _distance, _whatIsWall));

    }

    #endregion

    #region FlipRegion

    public void Flip(float facingDirection)
    {
        this.facingDirection = facingDirection;
        if(!canFlip) return;
        if (facingDirection > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        else if (facingDirection < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }
    #endregion
    
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(_boxTrm.position,_boxSize);
    }
#endif
}
