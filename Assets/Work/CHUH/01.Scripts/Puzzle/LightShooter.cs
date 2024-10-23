using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightShooter : MonoBehaviour, IInteractable
{
    public float ShootTime = 1.0f; // 빛 쏘는 시간
    public float ColTime = 3.0f; // 빛 쿨타임
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 20); // 레이 쏴서 거룰 있나 체크
        if (hit.collider != null&&hit.transform.CompareTag("Mirror")) // 닿은놈이 거울이면
        {
            _lineRenderer.positionCount = positionCount + 1; // lineRander 점 개수 1개 늘리기
            _lineRenderer.SetPosition(1,transform.InverseTransformPoint(hit.transform.position));
            // 다음 점을 맞은 거울의 위치로 설정(로컬로 전환한 이유는 LineRander의 그려지는걸 로컬로 설정해서)
            MirrorReflection hitMirror = hit.transform.GetComponent<MirrorReflection>();
            hit.transform.GetComponent<MirrorReflection>()?.ReflectionMirror(_lineRenderer,Vector2.up,this);
            // 맞은 거울의 반사 스크립트 실행(라인렌더러, 들어가는 방향, 이 오브젝트(local 포지션 계산 위함))
            hit.transform.GetComponent<LightSensor>()?.ExecutionEvent();
            // 빛감지 장치면 이벤트 실행
        }
    }

    private IEnumerator LightColtime() // 빛 쏘고, 빛이 일정시간후 꺼지고, 일정시간 후 다시 상호작용 가능
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

    public void Interact()
    {
        FireLight();
    }
}
