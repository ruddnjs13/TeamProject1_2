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
        Debug.Log("Dash");
        _owner.SetMovement(Vector2.zero);
        Vector2 dir = _owner.transform.right * dashPower * 5f;
        _owner._isDahing = true;
        _owner.playerInput._isDashing = true;
        _prevGravityScale = _owner.RbCompo.gravityScale;
        _owner.RbCompo.gravityScale = 0f;
        _owner.SetMovement(dir);
    }

    private void DashEndCheck()
    {
    }

    private void Update()
    {
        if (_owner._isDahing)
        {
            _dashtime += Time.deltaTime;
        }

        if (_dashtime >= _maxDashTime)
        {
            Debug.Log("대쉬엔드!");
            _dashtime = .0f;
            _owner.playerInput._isDashing = false;
            _owner._isDahing = false;
            _owner.RbCompo.gravityScale = _prevGravityScale;
            _owner.SetMovement(Vector2.zero);
        }
    }

    public override void OnSkillEnd()
    {
        // 스킬 끝날 시 실행
    }
}