using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightShooter : MonoBehaviour, IInteractable
{
    [SerializeField] private float ShootTime = 1.0f; // �� ��� �ð�
    [SerializeField] private float ColTime = 3.0f; // �� ��Ÿ��
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 20); // ���� ���� �ŷ� �ֳ� üũ
        if (hit.collider != null&&hit.transform.CompareTag("Mirror")) // �������� �ſ��̸�
        {
            _lineRenderer.positionCount = positionCount + 1; // lineRander �� ���� 1�� �ø���
            _lineRenderer.SetPosition(1,transform.InverseTransformPoint(hit.transform.position));
            // ���� ���� ���� �ſ��� ��ġ�� ����(���÷� ��ȯ�� ������ LineRander�� �׷����°� ���÷� �����ؼ�)
            MirrorReflection hitMirror = hit.transform.GetComponent<MirrorReflection>();
            hit.transform.GetComponent<MirrorReflection>().ReflectionMirror(_lineRenderer,Vector2.up,this);
            // ���� �ſ��� �ݻ� ��ũ��Ʈ ����(���η�����, ���� ����, �� ������Ʈ(local ������ ��� ����))
        }
    }

    private IEnumerator LightColtime() // �� ���, ���� �����ð��� ������, �����ð� �� �ٽ� ��ȣ�ۿ� ����
    {
        isCanLightShoot = false;
        yield return new WaitForSeconds(ShootTime);
        _lineRenderer.positionCount = 1;
        yield return new WaitForSeconds(ColTime);
        isCanLightShoot = true;
    }

    public void ShowInteractText()
    {

    }

    public void StartInteract()
    {
    }

    public void Interact()
    {
        FireLight();
    }

    public void EndInteract()
    {
    }
}
