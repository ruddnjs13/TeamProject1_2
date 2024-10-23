using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationTextUI : MonoBehaviour, IInteractable
    // �׽�Ʈ �� ��ũ��Ʈ,  ���� ���� ����
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
