using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Slow();
        }
    }

    private void Slow()
    {
        Debug.Log("얍!");
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}