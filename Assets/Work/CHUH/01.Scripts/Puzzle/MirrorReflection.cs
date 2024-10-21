using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    Ray ray;
    Ray ray2;
    private BoxCollider2D col;
    // Vector.right가 법선벡터
    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        ray = new Ray(transform.position, transform.right);
        Debug.DrawRay(transform.position, Vector3.up * 5);
    }
    public void ReflectionLight(LineRenderer line,Vector2 dir)
    {
        Vector2 reflectionVector = Vector2.Reflect(dir, transform.right);
        Debug.Log(reflectionVector);
        col.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, reflectionVector,20);
        ray2 = new Ray(transform.position, reflectionVector * 20);
        int count = line.positionCount;
        line.positionCount++;
        if (hit.collider != null)
        {
            line.SetPosition(count, hit.transform.position);
            if (hit.transform.CompareTag("Mirror"))
            {
                Debug.Log(count);
                Debug.Log("거울에또맞음");
                Debug.Log(hit.transform.position);
                hit.transform.GetComponent<MirrorReflection>().ReflectionLight(line, reflectionVector);
            }
            else
            {

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray);
        Gizmos.DrawRay(ray2);
    }
}
