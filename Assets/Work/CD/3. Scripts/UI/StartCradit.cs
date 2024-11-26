using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StartCradit : MonoBehaviour
{
    [SerializeField] private float startDelay, typingDelay, nextDelay;
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private List<string> _texts;

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