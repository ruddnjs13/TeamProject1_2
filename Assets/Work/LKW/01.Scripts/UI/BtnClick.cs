using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnClick : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    public BtnType btnType;
    
    private Vector3 originScale;

    private void Start()
    {
        originScale = transform.localScale;
    }

    public void BtnClicked()
    {
        BtnManager.Instance.SetBtnAndClick(btnType);
    }

    public void PlayEffect()
    {
        BtnManager.Instance.PlayEffect(transform.position);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originScale * 1.2f;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originScale;
    }
}
