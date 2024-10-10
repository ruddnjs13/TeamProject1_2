 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScreenColorFeedback : Feedback
{
    private Light2D _light;
    private Color _previousColor;
    public override void PlayFeedback()
    {
        if (_light == null)
        {
            _light = GameObject.Find("Light 2D").GetComponent<Light2D>();
        }
        _previousColor = _light.color;
        _light.color = Color.Lerp(_previousColor, Color.blue, 0.5f);
    }

    public override void StopFeedback()
    {
        _light.color = _previousColor;
    }
}
