using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightShooter : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private int positionCount = 1;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        _lineRenderer.SetPosition(0, transform.position);
        ShootLight();
    }
    private void ShootLight()
    {
        Debug.Log("½´¿ô");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 20);
        if (hit.collider != null&&hit.transform.CompareTag("Mirror"))
        {
            Debug.Log("°Å¿ï¿¡¸ÂÀ½");
            _lineRenderer.positionCount = ++positionCount;
            _lineRenderer.SetPosition(1, hit.transform.position);
            hit.transform.GetComponentInChildren<MirrorReflection>().ReflectionLight(_lineRenderer,Vector2.up);
        }
    }
}
