using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public enum BtnType
{
    None,
    Start,
    Setting,
    Exit,
    Video,
    Audio,
    KeySetting
}

public class BtnManager : MonoSingleton<BtnManager>
{
    [SerializeField] private GameObject _settingUI;
    [SerializeField] private GameObject _titleUI;
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
                _titleUI.SetActive(false);
                _settingUI.SetActive(true);
                break;
            case BtnType.Exit:
                break;
            case BtnType.Video:
                break;
            case BtnType.Audio:
                break;
            case BtnType.KeySetting:
                break;
        }
    }

    public void SetBtnAndClick(BtnType btnType)
    {
        _btnType = btnType;
        BtnClick();
    }
}
