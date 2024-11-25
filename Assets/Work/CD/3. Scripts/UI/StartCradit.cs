using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;


public class StartCradit : MonoBehaviour
{
    [SerializeField] private float _delayValue;
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private List<string> _texts;

    private Sequence _fadeSeq;

    private void Start()
    {
        TextPrint();
    }

    private void TextPrint()
    {
        _fadeSeq = DOTween.Sequence();
        foreach (var text in _texts)
        {
                _fadeSeq.AppendInterval(_delayValue)
                .Append(targetText.DOFade(0f, 1f).OnComplete((() => targetText.text = text)))
                .Append(targetText.DOFade(1f, 1f));
        }
        _fadeSeq
            .AppendInterval(_delayValue)
            .Append(targetText.DOFade(0f, 1f));
    }
}