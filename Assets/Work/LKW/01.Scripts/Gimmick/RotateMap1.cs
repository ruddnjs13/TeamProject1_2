using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class RotateMap1 : MonoBehaviour,IInteractable
{
    private Transform _playerTrm;
    private float _time;
    private GameObject _grid;
    private Transform _rotateAxis;
    private GameObject _showDirection;
    
    private PlayerInteraction _playerInteraction;
    private bool isRotate = false;
    public bool _canRotate = false;

    private Quaternion _leftRot, _rightRot;

    private void Awake()
    {
        _showDirection = transform.Find("ShowDirection").gameObject;
    }

    private void Start()
    {
        _leftRot = Quaternion.Euler(0, 0, -90f);
        _rightRot = Quaternion.Euler(0, 0, 90f);
    }

    private void Update()
    {
        ChooseDirectionAndStart();
    }

    private void ChooseDirectionAndStart()
    {
        if (!_canRotate)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateManager.Instance.CurrentRotationIdx = ++RotateManager.Instance.CurrentRotationIdx % 4;
            MapRotate(_leftRot);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            RotateManager.Instance.CurrentRotationIdx = --RotateManager.Instance.CurrentRotationIdx;
            if (RotateManager.Instance.CurrentRotationIdx < 0)
            {
                RotateManager.Instance.CurrentRotationIdx = 3;
            }
            MapRotate(_rightRot);
        }
    }

    private void MapRotate(Quaternion direction)
    {
        RotateManager.Instance.StartRotateEvent?.Invoke();
        if (isRotate) return;
        
        StopAllCoroutines();
        
        Vector3 previousPos = _grid.transform.position;

        _rotateAxis.transform.position = _playerTrm.position;
        
        _grid.transform.position = previousPos;
        
        isRotate = true;
        
        Physics2D.gravity = new Vector2(0, 0);
        
        StartCoroutine(MapRotateCoroutine(direction));
    }

    private IEnumerator MapRotateCoroutine(Quaternion direction)
    {
        Quaternion start = _rotateAxis.transform.rotation;
        float current = 0;
        float percent = 0;
        
        Quaternion target = start * direction;


        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / _time;

            _rotateAxis.transform.rotation = Quaternion.Lerp(start, target, percent);
            yield return null;
        } 
        

        Physics2D.gravity = new Vector2(0, -9.81f);
        isRotate = false;
        _canRotate = false;
        RotateManager.Instance.EndRotateEvent?.Invoke();
    }

    public void Interact()
    {
        Debug.Log(transform.localEulerAngles.z);
        Debug.Log(RotateManager.Instance.CurrentRotationIdx);
        Debug.Log(RotateManager.Instance._rotations1[RotateManager.Instance.CurrentRotationIdx]);
        if (transform.localEulerAngles.z ==
            RotateManager.Instance._rotations1[RotateManager.Instance.CurrentRotationIdx])
        {
            _canRotate = true;
            _showDirection.SetActive(true);
        }
    }

    public void EndInteract()
    {
        _canRotate = false;
        _showDirection.SetActive(false);
    }

    public void Initialize(Transform playerTrm, Transform rotateAxis, GameObject grid, float time)
    {
        _playerTrm = playerTrm;
        _rotateAxis = rotateAxis;
        _grid = grid;
        _time = time;
    }
}
