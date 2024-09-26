using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSO : MonoBehaviour
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
