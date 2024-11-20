using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resolutionText;
    [SerializeField] private TextMeshProUGUI _fullScreenText;

    private List<Vector2> _resolutions = new List<Vector2>()
    {
        new Vector2(1280, 720),
        new Vector2(1920, 1080),
        new Vector2(2560, 1440)
    };

    private List<FullScreenMode> _screenModes = new List<FullScreenMode>()
    {
        FullScreenMode.FullScreenWindow,
        FullScreenMode.Windowed
    };
    
    private int currentResolutionIndex = 1;
    private int currentScreenModeIndex = 0;
    

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        currentResolutionIndex = 1;
        currentScreenModeIndex = 0;
        Screen.fullScreenMode = _screenModes[currentScreenModeIndex];
        Screen.SetResolution((int)_resolutions[currentResolutionIndex].x,
            (int)_resolutions[currentResolutionIndex].y,true);
        _resolutionText.text = $"{_resolutions[currentResolutionIndex].x} x {_resolutions[currentResolutionIndex].y}";
        _fullScreenText.text = "ON";
    }

    public void SetScreenMode(int value)
    {
        if ((currentScreenModeIndex + value) < 0)
            currentScreenModeIndex = 1;
        else
            currentScreenModeIndex = (currentScreenModeIndex + value) % 2;
        
        Screen.fullScreenMode = _screenModes[currentScreenModeIndex];
        if (currentScreenModeIndex == 0)
            _fullScreenText.text = "ON";
        else
            _fullScreenText.text = "OFF";
    }

    public void SetResolution(int value)
    {
        if (currentResolutionIndex + value < 0)
            currentResolutionIndex = 2;
        else
            currentResolutionIndex = (currentResolutionIndex + value) % 3;
        
        Vector2 resolution = _resolutions[currentResolutionIndex];
        Screen.SetResolution((int)resolution.x,(int)resolution.y,Screen.fullScreenMode);
        _resolutionText.text = $"{resolution.x} x {resolution.y}";

       
    }
}
