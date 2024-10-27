using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RotateMap : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform _rotateAxis;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private float time;
    [SerializeField] private GameObject _map;
    private GameObject _showDirection;
    
    private PlayerInteraction _playerInteraction;
    private bool isRotate = false;
    public bool _isInteract = false;

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

    private void TestRot()
    {
        var current = transform.rotation;
        var target = current * _rightRot;
        
        Quaternion.Lerp(_leftRot, _rightRot, time);
    }

    private void Update()
    {
        if (!_isInteract)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            MapRotate(_leftRot);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            MapRotate(_rightRot);
        }
    }

    public void MapRotate(Quaternion direction)
    {
        if (isRotate) return;
        
        
        StopAllCoroutines();
        
        Vector3 previousPos = _map.transform.position;

        _rotateAxis.transform.position = _playerTrm.position;
        
        _map.transform.position = previousPos;
        
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
            percent = current / time;

            _rotateAxis.transform.rotation = Quaternion.Lerp(start, target, percent);
            yield return null;
        } 
        

        Physics2D.gravity = new Vector2(0, -9.81f);
        isRotate = false;
        _isInteract = false;
        
    }

    public void StartInteract()
    {
        _isInteract = true;
        _showDirection.SetActive(true);
    }

    public void Interact()
    {
        Debug.Log("상호작용가능");
        StartInteract();
    }

    public void EndInteract()
    {
        _isInteract = false;
        _showDirection.SetActive(false);
    }
}
