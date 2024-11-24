using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialText : MonoBehaviour
{
    private void Start()
    {
        transform.DOLocalMoveY(transform.position.y -0.4f, 0.5f)
            .SetEase(Ease.OutCirc)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
