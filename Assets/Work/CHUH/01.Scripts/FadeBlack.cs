using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    public void Fade(bool inOut)
    {
        Sequence sequence = DOTween.Sequence();
        if (inOut)
        {
            sequence.Append(_image.DOFade(1, 0.7f)).AppendInterval(0.5f);
            sequence.OnComplete(() => GameManager.Instance.NextSceneLoad());
        }
        else
        {
            sequence.Append(_image.DOFade(0, 0.7f));
        }
    }
}
