using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightShooter : MonoBehaviour, IInteractable
{
    private bool isCanLightShoot = true;
    private LineRenderer _lineRenderer;
    private int positionCount = 1;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        _lineRenderer.SetPosition(0, Vector3.zero); // ������ �� ��ġ �ڽ�����(local �� ���ϱ� �̰���)
    }
    private void FireLight()
    {
        if (!isCanLightShoot) return;
        Debug.Log("���� ������");
        StartCoroutine(LightColtime());
        _lineRenderer.SetPosition(0, Vector3.zero); // ������ �� ��ġ �ڽ�����(local �� ���ϱ� �̰���)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 20); // ���� ���� �ŷ� �ֳ� üũ
        if (hit.collider != null&&hit.transform.CompareTag("Mirror")) // �������� �ſ��̸�
        {
            _lineRenderer.positionCount = positionCount + 1; // lineRander �� ���� 1�� �ø���
            _lineRenderer.SetPosition(1,transform.InverseTransformPoint(hit.transform.position)); 
            // ���� ���� ���� �ſ��� ��ġ�� ����(���÷� ��ȯ�� ������ LineRander�� �׷����°� ���÷� �����ؼ�)
            hit.transform.GetComponent<MirrorReflection>().ReflectionLight(_lineRenderer,Vector2.up,this);
            // ���� �ſ��� �ݻ� ��ũ��Ʈ ����(���η�����, ���� ����, �� ������Ʈ(local ������ ��� ����))
        }
    }

    private IEnumerator LightColtime()
    {
        isCanLightShoot = false;
        yield return new WaitForSeconds(1);
        _lineRenderer.positionCount = 1;
        yield return new WaitForSeconds(3);
        isCanLightShoot = true;
    }

    public void StartInteract()
    {

    }

    public void Interact()
    {
        FireLight();
    }
}
