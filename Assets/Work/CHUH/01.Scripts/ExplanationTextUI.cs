using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationTextUI : MonoBehaviour, IInteractable
    // 테스트 용 스크립트,  추후 수정 예정
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text.enabled = false;
    }
    public void ShowExplanationText()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(image.DOFade(0.6f, 0.25f));
        sequence.OnComplete(() =>
        {
            text.enabled = true;
            TMPDOText(text, 1.5f);
        });

    }
    
    private void TMPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;
        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration).SetEase(Ease.Linear);
    }

    public void ShowInteractText()
    {

    }

    public void Interact()
    {
        ShowExplanationText();
    }
}
