using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    Ray ray;
    // Vector.right가 법선벡터
    private void Start()
    {
        ray = new Ray(transform.position, transform.right);
        Debug.DrawRay(transform.position, Vector3.up * 5);
    }
    public void ReflectionLight(LineRenderer line,Vector2 dir)
    {
        int count = line.positionCount+=1;
        Vector2 reflectionVector = Vector2.Reflect(dir, transform.right);
        Debug.Log(reflectionVector);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, reflectionVector,20);
        if (hit.collider != null && hit.transform.CompareTag("Mirror"))
        {
            Debug.Log("거울에또맞음");
        }
            //    line.SetPosition(count, hit.transform.position);
            //    hit.transform.GetComponentInChildren<MirrorReflection>().ReflectionLight(line, reflectionVector);
            //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray);
    }
}
