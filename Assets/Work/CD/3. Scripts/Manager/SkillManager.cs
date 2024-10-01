using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Dash
}


public class SkillManager : MonoSingleton<SkillManager>
{
    public Dictionary<Type, Skill> Skills;

    private Player _player;

    private void Awake()
    {
        Skills = new Dictionary<Type, Skill>();
    }
    

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        foreach (SkillType skillType in Enum.GetValues(typeof(SkillType)))
        {
            Skill skillCompo = GetComponent($"{skillType.ToString()}Skill") as Skill;
            if (skillCompo != null)
            {
                skillCompo.Initialize(_player);
                
                Type type = skillCompo.GetType();
                // Debug.Log(type);
                // Debug.Log(skillCompo);
                
                Skills.Add(type, skillCompo);
            }
        }
    }

    public T GetSkill<T>() where T : Skill
    {
        Type t = typeof(T);
        if (Skills.TryGetValue(t, out var targetSkill)) // 해당 Key가 있으면 True
        {
            return targetSkill as T;
        }

        return null;
    }
}