using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    public CinemachineVirtualCamera Cam2;

    [SerializeField] protected float nowCamScale;

    public void SetPoint(Transform point)
    {
        Cam2.Follow = point;
    }
    public void SetSize(float size)
    {
        nowCamScale = size;
    }

    public void SetCam()
    {
        // DOTween.To(() => cinemachine.m_Lens.OrthographicSize, x => cinemachine.m_Lens.OrthographicSize = x, CamScale, 5f);
        // 원인은 모르겠으나, 개 끊겨 나와서 기각

        Cam2.Priority = 100;
        Cam2.m_Lens.OrthographicSize = nowCamScale;
    }

    public void SetTimeCam(float time)
    {
        StartCoroutine(TimeSet(time));
    }
    private IEnumerator TimeSet(float time)
    {
        Cam2.Priority = 100;
        Cam2.m_Lens.OrthographicSize = nowCamScale;
        yield return new WaitForSeconds(time);
        Cam2.Priority = 0;
    }
    public void UnSetCam()
    {
        Cam2.Priority = 0;
    }

}
