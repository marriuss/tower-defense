using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    private const string IdleAnimation = "Idle";
    private const string MoveAnimation = "Move";
    private const string AttackAnimation = "Attack";
    private const string TakeHitAnimation = "TakeHit";
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
        PlayAnimation(AttackAnimation);
    }

    public void PlayTakeHitAnimation()
    {
        PlayAnimation(TakeHitAnimation);
    }

    public void PlayDeathAnimation()
    {
        PlayAnimation(DeathAnimation);
    }

    private void PlayAnimation(string animation)
    {
        _animator.Play(animation);
    }

    internal void Stop()
    {
       _animator.StopPlayback();
    }
}
