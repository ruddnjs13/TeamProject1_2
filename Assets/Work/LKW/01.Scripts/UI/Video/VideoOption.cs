using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoOption : MonoBehaviour
{
    private List<Resolution> resolutions = new List<Resolution>();
    
    private FullScreenMode screenMode;
    
    private int currentResolutionIndex = 1;
    

    private void Start()
    {
        resolutions.Add(Screen.resolutions[3]);
        resolutions.Add(Screen.resolutions[12]);
        resolutions.Add(Screen.resolutions[14]);
        
        int count = 0;
        foreach (Resolution resolution in resolutions)
        {
            Debug.Log($"{count++}  {resolution.ToString()}");
        }
    }

    public void SetResolution(int value)
    {
        Resolution resolution = resolutions[currentResolutionIndex + value];
        Screen.SetResolution(resolution.width, resolution.height,true);
    }
}
