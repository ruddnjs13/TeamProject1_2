using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public enum BtnType
{
    None,
    Start,
    Setting,
    Exit
}

public class BtnManager : MonoSingleton<BtnManager>
{
    BtnType _btnType = BtnType.None;
    
    private FeedbackPlayer _feedbackPlayer;

    private void Awake()
    {
        _feedbackPlayer = GetComponentInChildren<FeedbackPlayer>();
    }

    private void BtnClick()
    {
        switch (_btnType)
        {
            case BtnType.Start: 
                SceneManager.LoadScene(1);
                break;
            case BtnType.Setting:
                break;
            case BtnType.Exit:
                break;
        }
    }

    public void SetBtnAndClick(BtnType btnType)
    {
        _btnType = btnType;
        BtnClick();
    }
}
