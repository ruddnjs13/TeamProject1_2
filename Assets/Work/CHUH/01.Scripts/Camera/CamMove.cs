using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    public CinemachineVirtualCamera Cam2;

    [SerializeField] private Transform nowCamMovePoint;
    [SerializeField] protected float nowCamScale;

    public void SetPoint(Transform point)
    {
        nowCamMovePoint = point;
    }
    public void SetSize(float size)
    {
        nowCamScale = size;
    }

    public void SetCam()
    {
        // DOTween.To(() => cinemachine.m_Lens.OrthographicSize, x => cinemachine.m_Lens.OrthographicSize = x, CamScale, 5f);
        // ������ �𸣰�����, �� ���� ���ͼ� �Ⱒ

        Cam2.Priority = 100;
        Cam2.m_Lens.OrthographicSize = nowCamScale;
        Cam2.Follow = nowCamMovePoint;
    }
    public void UnSetCam()
    {
        Cam2.Priority = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetCam();
        }
        if (Input.GetMouseButtonDown(1))
        {
            UnSetCam();
        }
    }
}
