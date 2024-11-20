using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "SO/FSM/State")]
public class TargetLaserStateSO : ScriptableObject
{
    public string stateName;
    public string className;
    public LoopType loopType;
    public Ease _easeType;
}
