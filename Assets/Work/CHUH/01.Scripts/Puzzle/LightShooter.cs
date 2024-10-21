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
        Debug.DrawRay(transform.position, Vector2.up);
        if (hit.collider != null&&hit.transform.CompareTag("Mirror"))
        {
            Debug.Log("°Å¿ï¿¡¸ÂÀ½");
            Debug.Log(hit.transform.position);
            _lineRenderer.positionCount = ++positionCount;
            _lineRenderer.SetPosition(1, hit.transform.position);
            hit.transform.GetComponent<MirrorReflection>().ReflectionLight(_lineRenderer,Vector2.up);
        }
    }
}
