using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightShooter : MonoBehaviour, IInteractable
{
    [SerializeField] private float ShootTime = 1.0f; 
    [SerializeField] private float Colltime = 3.0f;
    private bool isCanLightShoot = true;
    private BoxCollider2D _colider;
    private LineRenderer _lineRenderer;
    private int positionCount = 1;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _colider = GetComponent<BoxCollider2D>();
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position+transform.right, transform.right, 20);
        if (hit.collider != null)
        {
            _lineRenderer.positionCount = positionCount + 1;
            if (hit.collider.transform.CompareTag("Mirror"))
            {
                Debug.Log("거울에맞음");
                _lineRenderer.SetPosition(1, transform.InverseTransformPoint(hit.collider.transform.position));
                hit.collider.transform.GetComponent<MirrorReflection>()?.ReflectionMirror(_lineRenderer, transform.right, this);
                hit.collider.transform.GetComponent<LightSensor>()?.ExecutionEvent();
            }
            else _lineRenderer.SetPosition(1, transform.InverseTransformPoint(hit.point));

        }
    }

    private IEnumerator LightColtime()
    {
        isCanLightShoot = false;
        yield return new WaitForSeconds(ShootTime);
        _lineRenderer.positionCount = 1;
        yield return new WaitForSeconds(Colltime);
        isCanLightShoot = true;
        _colider.enabled = true;
    }


    public void Interact()
    {
        FireLight();
        _colider.enabled = false;
    }

    public void EndInteract()
    {
    }
}
