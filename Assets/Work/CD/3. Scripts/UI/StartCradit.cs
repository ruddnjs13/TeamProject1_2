using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class StartCradit : MonoBehaviour
{
    [SerializeField] private float startDelay, typingDelay, nextDelay;
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private List<string> _texts;
    [SerializeField] private string _mainText;
    
    private Sequence _seq;
    
    private void Start()
    {
        targetText.text = "";
        StartCoroutine(TextPrint());
    }

    private IEnumerator TextPrint()
    {
        yield return new WaitForSeconds(startDelay);
        foreach (var text in _texts)
        {
            StartCoroutine(TextTyping(text));
            yield return new WaitForSeconds(nextDelay);
            StartCoroutine(TextDelete(text));
            yield return new WaitForSeconds(nextDelay);
            targetText.text = "";
        }

        _seq = DOTween.Sequence()
            .Append(targetText.DOFade(0f, 1f).OnComplete(() => targetText.text = _mainText))
            .Append(targetText.DOFade(1f, 1f))
            .AppendInterval(3f)
            .Append(targetText.DOFade(0f, 1f));
    }

    private IEnumerator TextTyping(string text)
    {
        foreach (var t in text)
        {
            targetText.text += t;
            yield return new WaitForSeconds(typingDelay);
        }
    }

    private IEnumerator TextDelete(string text)
    {
        int length = text.Length;

        while (length >= 0)
        {
            string t = text.Substring(0, length);
            targetText.text = t; 
            yield return new WaitForSeconds(typingDelay);
            length--;
        }
    }
}