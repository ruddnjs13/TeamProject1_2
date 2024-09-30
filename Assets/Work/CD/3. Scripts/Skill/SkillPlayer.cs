using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlayer : MonoBehaviour
{
    // 스킬 모음
    public List<Skill> skills;

    private void Start()
    {
        // 스킬 다 받아주기
        LoadSkill();
        
        // 스킬 입력 다 받아주기
        LoadInputSkill();
    }

    private void LoadSkill()
    {
        skills = GetComponents<Skill>().ToList();
    }

    private void LoadInputSkill()
    {
        skills.ForEach(a => a.SetKey());
    }
}
