using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private bool isCanMoveing;

    [Header("Move Type")]
    [SerializeField] private MoveType HowToMove;

    [Header("Move Setting(local pos)")]
    [SerializeField] private bool isStartingToStart;
    [SerializeField] private Vector2 moveStartPos;
    [SerializeField] private Vector2 moveEndPos;
    [SerializeField] private float waitTime;
    [SerializeField] private float _duration;

    private Sequence _Sequnce;
    private void Start()
    {
        if (isStartingToStart) Moveing();
    }
    public void Moveing()
    {
        if (!isCanMoveing) return;
        switch (HowToMove)
        {
            case MoveType.LeftRight:
                Debug.Log("AA");
                _Sequnce = DOTween.Sequence();
                _Sequnce.AppendInterval(waitTime).
                    Append(transform.DOLocalMove(transform.position + (Vector3)moveEndPos, _duration).SetEase(Ease.Linear)).
                    AppendInterval(waitTime);
                _Sequnce.SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }
}
public enum MoveType
{
    LeftRight, UpDown
}