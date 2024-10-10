using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class RotateMap : MonoBehaviour
{
    [SerializeField] private GameObject _playerAxis;
    [SerializeField] private float time;
    private bool isRotate = false;
    private void Update()
    {
        if (Keyboard.current.rKey.isPressed)
        {
            Debug.Log("회전");
            StartCoroutine(MapRotateCoroutine());
        }
    }

    private IEnumerator MapRotateCoroutine()
    {
        float start = _playerAxis.transform.eulerAngles.z;
        float current = _playerAxis.transform.eulerAngles.z;
        float percent = 0;
        

        Vector3 _axisAngle = _playerAxis.transform.eulerAngles;
        float target = _axisAngle.z + 90f;


        while (percent <= 90f)
        {
            current += 1;
            percent = current / (time * 90);
            
            _playerAxis.transform.rotation = Quaternion.Euler
                (new Vector3(_axisAngle.x,_axisAngle.y,_axisAngle.z + Mathf.Lerp(start,target,percent)));
            yield return null;
        }
    }
}
