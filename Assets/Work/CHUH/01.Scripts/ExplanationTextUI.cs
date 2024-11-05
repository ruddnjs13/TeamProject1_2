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
    [SerializeField] private string TypingText;
    [SerializeField] private float TypingTime;
    private bool isExplanationUION = false;
    private BoxCollider2D ColCompo;

    private void Awake()
    {
        ColCompo = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        text.enabled = false;
    }
    private void ShowExplanationText()
    {
        Sequence sequence = DOTween.Sequence();
        text.text = TypingText;
        ColCompo.enabled = false;
        sequence.Append(image.DOFade(0.6f, 0.25f));

        sequence.OnComplete(() =>
        {
            text.enabled = true;
            isExplanationUION = true;
            TMPDOText(text, TypingTime);
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
        Sequence sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration).SetEase(Ease.Linear));
        sequence.OnComplete(() =>
        {
            ColCompo.enabled = true;
        });
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
    // TODO ��ȣ�ۿ��� ������ ����(�÷��̾� �ǵ��� �� �� ���Ƽ� ���߿� ����� ���� ���ؾ� ��.)
}
