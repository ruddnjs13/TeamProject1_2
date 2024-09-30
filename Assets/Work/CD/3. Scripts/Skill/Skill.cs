using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : MonoBehaviour
{
    protected Player _owner;
    
    // 스킬 피드백 이벤트
    public UnityEvent OnSkillActivated; 
    
    // 키 입력 alc 받아주는 메서드
    public abstract void SetKey();

    // 시작전에 기본값을 조정해주는 메서드
    public void Initialize(Player owner)
    {
        _owner = owner;
    }

    // 스킬 실행시 실행 메서드
    public abstract void OnSkill();
    
    // 스킬 끝날 시 실행 메서드
    public abstract void OnSkillEnd();
}
