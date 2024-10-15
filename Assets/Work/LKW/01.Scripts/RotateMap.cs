using System;
using System.Collections;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    [SerializeField] private GameObject _playerAxis;
    [SerializeField] private float time;

    [SerializeField] private GameObject _map;
    private bool isRotate = false;

    public void MapRotate()
    {
        StopAllCoroutines();
        Debug.Log("회전");
        isRotate = true;
        Physics2D.gravity = new Vector2(0, 0);
        _map.transform.SetParent(_playerAxis.transform);
        StartCoroutine(MapRotateCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MapRotate();
        }
    }

    private IEnumerator MapRotateCoroutine()
    {
        float start = 0;
        float current = 0;
        float percent = 0;

        Vector3 _axisAngle = _playerAxis.transform.eulerAngles;
        float target = 90;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            _playerAxis.transform.rotation = Quaternion.Euler
                (new Vector3(_axisAngle.x,_axisAngle.y,_axisAngle.z - Mathf.Lerp(start,target,percent)));
            yield return null;
        }

        Physics2D.gravity = new Vector2(0, -9.81f);
        _map.transform.SetParent(null);
        isRotate = false;
    }
}
