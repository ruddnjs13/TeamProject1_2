using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill")]
public class SkillSO : ScriptableObject
{
    [Header("SkillName")]
    public string skillName;
    public string skillDescription;
    
    [Header("Settings")]
    public float damage;
    public float cooldown;
    public Sprite skillIcon;
    
    [Header("SkillAnimation")]
    public string skillAnimationName;
}
