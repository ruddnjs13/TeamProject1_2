using System;
using System.Collections;
using UnityEngine;

public class RotateMap : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject _playerAxis;
    [SerializeField] private float time;
    [SerializeField] private GameObject _map;
    private PlayerInteraction _playerInteraction;
    private bool isRotate = false;
    private bool _readyUse = false;
    
    private void Update()
    {
        if (!_readyUse)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            MapRotate(-1);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            MapRotate(1);
        }
    }

    public void MapRotate(float directionX)
    {
        if (isRotate) return;
        StopAllCoroutines();
        Debug.Log("회전");
        isRotate = true;
        Physics2D.gravity = new Vector2(0, 0);
        _map.transform.SetParent(_playerAxis.transform);
        StartCoroutine(MapRotateCoroutine(directionX));
    }

    private IEnumerator MapRotateCoroutine(float directionX)
    {
        float start = 0;
        float current = 0;
        float percent = 0;

        Vector3 _axisAngle = _playerAxis.transform.eulerAngles;
        float target =  90;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            _playerAxis.transform.rotation = Quaternion.Euler
                (new Vector3(_axisAngle.x,_axisAngle.y,_axisAngle.z - (Mathf.Lerp(start,target,percent) * directionX)));
            yield return null;
        }

        Physics2D.gravity = new Vector2(0, -9.81f);
        _map.transform.SetParent(null);
        isRotate = false;
        _readyUse = false;
    }

    public void ShowInteractText()
    {
        
    }

    public void Interact()
    {
        Debug.Log("상호작용가능");
        _readyUse = true;
    }
}
