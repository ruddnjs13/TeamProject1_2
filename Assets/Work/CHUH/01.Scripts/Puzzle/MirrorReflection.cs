using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorReflection : MonoBehaviour, IInteractable
{
    Ray ray;
    Ray ray2;
    private BoxCollider2D col;
    private bool isCanRotate = true;
    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }
    
    public void ReflectionMirror(LineRenderer line, Vector2 dir, LightShooter shooter)
    {
        StartCoroutine(ReflectionLight(line, dir, shooter));
    }
    private IEnumerator ReflectionLight(LineRenderer line, Vector2 dir, LightShooter shooter)
    {
        yield return new WaitForSeconds(0.2f);
        col.enabled = false; 
        StartCoroutine(LightColtime());
        Vector3 reflectionVector = Vector2.Reflect(dir, transform.right); 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, reflectionVector, 20);
        int count = line.positionCount;
        line.positionCount++;
        if (hit.collider != null)
        {
            line.SetPosition(count, shooter.transform.InverseTransformPoint(hit.point));
            if (hit.transform.CompareTag("Mirror"))
            {
                hit.transform.GetComponent<MirrorReflection>()?.ReflectionMirror(line, reflectionVector, shooter);
                hit.transform.GetComponent<LightSensor>()?.ExecutionEvent();
            }
        }
        else
        {
            line.SetPosition(count, reflectionVector * 20 + transform.position);
        }
    }
    private IEnumerator LightColtime()
    {
        yield return new WaitForSeconds(1);
        col.enabled = true;
        yield return new WaitForSeconds(3);
    }


    public void StartInteract()
    {
    }

    public void Interact()
    {
        if (!isCanRotate) return;
        Sequence sequence = DOTween.Sequence();
        isCanRotate = false;
        col.enabled = false;
        sequence.Append(transform.DORotate(transform.rotation.eulerAngles + new Vector3(0, 0, 45f), 0.5f));
        sequence.OnComplete(() =>
        {
            isCanRotate = true;
            col.enabled = true;
        });
    }

    public void EndInteract()
    {
    }

    public void ShowInteractText()
    {
    }
}
