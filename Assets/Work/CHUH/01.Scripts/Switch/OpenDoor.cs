using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, ISwitchable
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float moveRange = 5f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private Vector2 StartPos;
    private void Awake()
    {
        StartPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Activate()
    {
        Debug.Log("�۵�");
        transform.DOMove(transform.position + transform.up * moveRange, duration);
    }
    public void Deactivate()
    {
        Debug.Log("�۵� ����");
        transform.DOMove(StartPos, duration);
    }
}
