using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill")]
public class SkillSO : ScriptableObject
{
    public string name;

    public int damage;
    public int cool;

    public string animationName;
}
