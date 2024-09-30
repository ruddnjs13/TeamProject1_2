using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    [SerializeField] private int dashPower;
    [SerializeField] private float _maxDashTime;
    
    private float _prevGravityScale;
    private float _dashtime = .0f;
    private bool _isDash = false;

    public override void SetKey()
    {
        _owner.playerInput.DashEvent += OnSkill;
    }

    public override void OnSkill()
    {
        // 스킬 실행 시 실행
        SkillDash();
    }

    private void SkillDash()
    {
        // 스킬 메서드
        _isDash = true;
        _owner._isDahing = true;
        _prevGravityScale = _owner.RbCompo.gravityScale;
        _owner.RbCompo.gravityScale = 0f;
        _owner.RbCompo.velocity = Vector2.right.normalized * (dashPower * 5f);
    }

    private void DashEndCheck()
    {
        if (_dashtime >= _maxDashTime)
        {
            _owner.RbCompo.gravityScale = _prevGravityScale;
            _dashtime = .0f;
            _owner.RbCompo.velocity = Vector2.zero;
            _owner._isDahing = false;
            _isDash = false;
        }
    }

    private void Update()
    {
        if (_isDash)
        {
            Debug.Log(_dashtime);
            _dashtime += Time.deltaTime;
            DashEndCheck();
        }
    }

    public override void OnSkillEnd()
    {
        // 스킬 끝날 시 실행
    }
}