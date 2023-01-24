using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private UnitControllerParameters _parameters;

    private const string MovingParameter = "Moving";
    private const string AttackTrigger = "Attack";
    private const string TakeHitTrigger = "TakeHit";
    private const string DieTrigger = "Die";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Dictionary<string, float> parameters = _parameters.Parameters;
        float value;

        foreach (string parameter in parameters.Keys)
        {
            value = parameters[parameter];

            if (value > 0)
                SetFloat(parameter, value);
        }
    }

    public void PlayIdleAnimation()
    {
        SetBool(MovingParameter, false);
    }

    public void PlayMoveAnimation()
    {
        SetBool(MovingParameter, true);
    }

    public void PlayAttackAnimation()
    {
        SetTrigger(AttackTrigger);
    }

    public void PlayTakeHitAnimation()
    {
        SetTrigger(TakeHitTrigger);
    }

    public void PlayDeathAnimation()
    {
        PlayAnimation(DieTrigger);
    }

    private void PlayAnimation(string animation)
    {
        _animator.Play(animation);
    }

    private void SetFloat(string parameter, float value)
    {
        _animator.SetFloat(parameter, value);
    }

    private void SetBool(string parameter, bool value)
    {
        _animator.SetBool(parameter, value);
    }

    private void SetTrigger(string trigger)
    {
        _animator.SetTrigger(trigger);
    }
}

[Serializable]
public struct UnitControllerParameters
{
    [SerializeField] private float _idleSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _takeHitSpeed;
    [SerializeField] private float _dieSpeed;

    public Dictionary<string, float> Parameters => new Dictionary<string, float>()
    {
        { "IdleSpeed", _idleSpeed },
        { "MoveSpeed", _moveSpeed },
        { "AttackSpeed", _attackSpeed },
        { "TakeHitSpeed", _takeHitSpeed },
        { "DieSpeed", _dieSpeed }
    };
}