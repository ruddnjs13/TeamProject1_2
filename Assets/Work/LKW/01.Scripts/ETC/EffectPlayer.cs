using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void SetPositionAndPlay(Vector3 position)
    {
        _particleSystem.transform.position = position;
        _particleSystem.Play();
    }
}
