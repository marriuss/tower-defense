using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    private const string IdleAnimation = "Idle";
    private const string MoveAnimation = "Move";
    private const string AttackTrigger = "Attack";
    private const string TakeHitTrigger = "TakeHit";
    private const string DeathAnimation = "Die";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        PlayAnimation(IdleAnimation);
    }

    public void PlayMoveAnimation()
    {
        PlayAnimation(MoveAnimation);
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
        PlayAnimation(DeathAnimation);
    }

    private void PlayAnimation(string animation)
    {
        _animator.Play(animation);
    }

    private void SetTrigger(string trigger)
    {
        _animator.SetTrigger(trigger);
    }
}
