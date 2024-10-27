using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, ISwitchble
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float moveRange = 5f;
    [SerializeField] private float duration = 1f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SwitchOnoff(bool onoff)
    {
        if(onoff == true)
        {
            Debug.Log("ÀÛµ¿");
            transform.DOLocalMove(transform.position + transform.up * moveRange, duration);
        }
        else
        {
            Debug.Log("²¨Áö");
        }
    }
}
