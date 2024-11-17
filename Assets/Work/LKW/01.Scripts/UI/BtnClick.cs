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
    
    private FeedbackPlayer _feedbackPlayer;

    private void Awake()
    {
        _feedbackPlayer = GetComponentInChildren<FeedbackPlayer>();
    }

    private void Start()
    {
        originScale = transform.localScale;
    }

    public void BtnClicked()
    {
        BtnManager.Instance.SetBtnAndClick(btnType);
    }

    public void EnterFeedback()
    {
        _feedbackPlayer.PlayFeedback();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originScale * 1.2f;
        EnterFeedback();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originScale;
    }
}
