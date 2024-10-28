using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightShooter : MonoBehaviour, IInteractable
{
    [SerializeField] private float ShootTime = 1.0f; 
    [SerializeField] private float Colltime = 3.0f;
    [SerializeField] private LayerMask WhatIsNotPlayer;
    private bool isCanLightShoot = true;
    private LineRenderer _lineRenderer;
    private int positionCount = 1;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        _lineRenderer.SetPosition(0, Vector3.zero);
    }
    private void FireLight()
    {
        if (!isCanLightShoot) return;
        Debug.Log("발진");
        StartCoroutine(LightColtime());
        _lineRenderer.SetPosition(0, Vector3.zero);
        RaycastHit2D hit = Physics2D.Raycast(transform.position+transform.right, transform.right, 20, WhatIsNotPlayer);
        if (hit.collider != null)
        {
            if (hit.collider.transform.CompareTag("Mirror"))
            {
                Debug.Log("거울에맞음");
                _lineRenderer.positionCount = positionCount + 1;
                _lineRenderer.SetPosition(1, transform.InverseTransformPoint(hit.collider.transform.position));
                MirrorReflection hitMirror = hit.transform.GetComponent<MirrorReflection>();
                hit.collider.transform.GetComponent<MirrorReflection>()?.ReflectionMirror(_lineRenderer, Vector2.right, this);
                hit.collider.transform.GetComponent<LightSensor>()?.ExecutionEvent();
            }
            
        }
    }

    private IEnumerator LightColtime()
    {
        isCanLightShoot = false;
        yield return new WaitForSeconds(ShootTime);
        _lineRenderer.positionCount = 1;
        yield return new WaitForSeconds(Colltime);
        isCanLightShoot = true;
    }

    public void ShowInteractText()
    {

    }

    public void StartInteract()
    {
    }

    public void Interact()
    {
        FireLight();
    }

    public void EndInteract()
    {
    }
}
