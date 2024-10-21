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
        _lineRenderer.SetPosition(0, Vector3.zero); // 최초의 점 위치 자신으로(local 계 쓰니깐 이거임)
    }
    private void FireLight()
    {
        if (!isCanLightShoot) return;
        Debug.Log("빛이 있으라");
        StartCoroutine(LightColtime());
        _lineRenderer.SetPosition(0, Vector3.zero); // 최초의 점 위치 자신으로(local 계 쓰니깐 이거임)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 20); // 레이 쏴서 거룰 있나 체크
        if (hit.collider != null&&hit.transform.CompareTag("Mirror")) // 닿은놈이 거울이면
        {
            _lineRenderer.positionCount = positionCount + 1; // lineRander 점 개수 1개 늘리기
            _lineRenderer.SetPosition(1,transform.InverseTransformPoint(hit.transform.position)); 
            // 다음 점을 맞은 거울의 위치로 설정(로컬로 전환한 이유는 LineRander의 그려지는걸 로컬로 설정해서)
            hit.transform.GetComponent<MirrorReflection>().ReflectionLight(_lineRenderer,Vector2.up,this);
            // 맞은 거울의 반사 스크립트 실행(라인렌더러, 들어가는 방향, 이 오브젝트(local 포지션 계산 위함))
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

    public void ShowInteractText()
    {

    }

    public void Interact()
    {
        FireLight();
    }
}
