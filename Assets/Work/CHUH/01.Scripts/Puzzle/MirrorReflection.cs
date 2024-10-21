using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    Ray ray;
    Ray ray2;
    private BoxCollider2D col;
    private bool isCanTeflection = true;
    // Vector.right�� ��������
    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }
    
    public void ReflectionLight(LineRenderer line,Vector2 dir, LightShooter shooter) // �ݺ��Ǿ� ȣ��Ǵ� �ſ� �ݻ�
    {
        col.enabled = false; // �� �ſ��� �¾����� �ٽ� ���� ���ϰ� �ص�(���صθ� ���ֺ��� �ſ￡�� ����ȣ��)
        StartCoroutine(LightColtime());
        Vector2 reflectionVector = Vector2.Reflect(dir, transform.right); // �Ի簢�� �������ͷ� �ݻ簢 ����.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, reflectionVector,20);
        // Shooteró�� Ray ���� �˻�
        if (hit.collider != null) // ����
        {
            int count = line.positionCount;
            line.positionCount++;
            // �� ���� �ø���(�ſ￡ �ȸ´��� �������� ������ �� �׷��� �ϴϱ�)
            line.SetPosition(count, shooter.transform.InverseTransformPoint(hit.transform.position)); // �������� �� ���
            if (hit.transform.CompareTag("Mirror")) // �ſ￡ ��������?
            {
                hit.transform.GetComponent<MirrorReflection>().ReflectionLight(line, reflectionVector,shooter); // �׷��� �ٽ� �ݻ�
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
