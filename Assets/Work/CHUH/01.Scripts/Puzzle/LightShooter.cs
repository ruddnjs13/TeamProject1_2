using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightShooter : MonoBehaviour, IInteractable
{
    [SerializeField] private float ShootTime = 1.0f; 
    [SerializeField] private float Colltime = 3.0f;
    [SerializeField] private LayerMask WhatIsActive;
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

        StartCoroutine(LightColtime());
        _lineRenderer.SetPosition(0, Vector3.zero);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 20, WhatIsActive);
        if (hit.collider.gameObject.layer==14)
        {
            _lineRenderer.positionCount = positionCount + 1;
            _lineRenderer.SetPosition(1,transform.InverseTransformPoint(hit.transform.position));
            MirrorReflection hitMirror = hit.transform.GetComponent<MirrorReflection>();
            hit.transform.GetComponent<MirrorReflection>()?.ReflectionMirror(_lineRenderer, Vector2.up, this);
            hit.transform.GetComponent<LightSensor>()?.ExecutionEvent();
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
