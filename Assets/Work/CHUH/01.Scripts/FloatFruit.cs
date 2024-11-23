using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatFruit : MonoBehaviour
{
    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(transform.DOLocalMoveY(transform.localPosition.y+0.05f, 0.5f).SetEase(Ease.InSine))
            .SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
