using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class FloatFruit : MonoBehaviour
{
    public UnityEvent EatEvent;

    private Sequence doTweenSEquence;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        doTweenSEquence = DOTween.Sequence();
        doTweenSEquence
            .Append(transform.DOLocalMoveY(transform.localPosition.y+0.05f, 0.5f).SetEase(Ease.InSine))
            .SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doTweenSEquence.Kill();
            transform.DOMove(collision.transform.position, 0.75f)
                .OnComplete(() => sprite.DOFade(0, 1f))
                .OnComplete(() => EatEvent?.Invoke());

        }
    }
}
