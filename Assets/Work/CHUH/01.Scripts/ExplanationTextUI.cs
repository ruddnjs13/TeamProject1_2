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
    [SerializeField] private string TypingText;
    private bool isExplanationUION = false;

    private void Start()
    {
        text.enabled = false;
    }
    private void ShowExplanationText()
    {
        Sequence sequence = DOTween.Sequence();
        text.text = TypingText;
        sequence.Append(image.DOFade(0.6f, 0.25f));
        sequence.OnComplete(() =>
        {
            text.enabled = true;
            isExplanationUION = true;
            TMPDOText(text, 1.5f);
        });
    }
    private void HideExplanationText()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(image.DOFade(0f, 0.25f));
        text.enabled = false;
        sequence.OnComplete(() =>
        {
            isExplanationUION = false;
        });
    }
    
    private void TMPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;
        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration).SetEase(Ease.Linear);
    }


    public void StartInteract()
    {

    }

    public void EndInteract()
    {

    }

    public void Interact()
    {
        if(!isExplanationUION)
        {
            ShowExplanationText();
        }
        else
        {
            HideExplanationText();
        }
    }
    // TODO 상호작용중 움직임 봉인(플레이어 건들어야 할 것 같아서 나중에 경원이 한테 말해야 함.)
}
