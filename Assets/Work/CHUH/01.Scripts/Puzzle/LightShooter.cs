using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightShooter : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        _lineRenderer.SetPosition(0, transform.position);
    }
    private void ShootLight()
    {
        Debug.DrawRay(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 20);
        if (hit.collider != null&&hit.transform.CompareTag("Mirror"))
        {

        }
    }
}
