using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowFeedback : Feedback
{
    private float previousTimeScale = .0f;
    private float previousFixedDelta = .0f;
    
    public override void PlayFeedback()
    {
        Slow();
    }

    public override void StopFeedback()
    {
        StopSlow();
    }

    private void StopSlow()
    {
        Debug.Log("그만!");
        Time.timeScale = previousTimeScale;
        Time.fixedDeltaTime = previousFixedDelta;
    }

    private void Slow()
    {
        Debug.Log("얍!");
        previousTimeScale = Time.timeScale;
        previousFixedDelta = Time.fixedDeltaTime;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
