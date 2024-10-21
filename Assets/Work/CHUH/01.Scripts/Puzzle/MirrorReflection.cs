using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    Ray ray;
    Ray ray2;
    private BoxCollider2D col;
    private bool isCanTeflection = true;
    // Vector.right가 법선벡터
    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }
    
    public void ReflectionLight(LineRenderer line,Vector2 dir, LightShooter shooter) // 반복되어 호출되는 거울 반사
    {
        col.enabled = false; // 이 거울은 맞았으니 다시 반응 안하게 해둠(안해두면 마주보는 거울에서 무한호출)
        StartCoroutine(LightColtime());
        Vector2 reflectionVector = Vector2.Reflect(dir, transform.right); // 입사각과 법선벡터로 반사각 구함.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, reflectionVector,20);
        // Shooter처럼 Ray 쏴서 검사
        if (hit.collider != null) // 조건
        {
            int count = line.positionCount;
            line.positionCount++;
            // 점 개수 늘리기(거울에 안맞더라도 맞은데에 마지막 점 그려야 하니깐)
            line.SetPosition(count, shooter.transform.InverseTransformPoint(hit.transform.position)); // 맞은데에 점 찍기
            if (hit.transform.CompareTag("Mirror")) // 거울에 맞은거임?
            {
                hit.transform.GetComponent<MirrorReflection>().ReflectionLight(line, reflectionVector,shooter); // 그러면 다시 반사
            }
            else
            {

            }
        }
    }
    private IEnumerator LightColtime()
    {
        isCanTeflection = false;
        yield return new WaitForSeconds(1);
        col.enabled = true;
        yield return new WaitForSeconds(3);
        isCanTeflection = true;
    }
    
}
