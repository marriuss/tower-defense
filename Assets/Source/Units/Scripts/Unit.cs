using NodeCanvas.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteFlipper))]
[RequireComponent(typeof(AnimationPlayer))]
public class Unit : MonoBehaviour, ITargetable
{
    [SerializeField] private UnitStats _stats;

    private SpriteFlipper _spriteFlipper;
    private AnimationPlayer _animationPlayer;

    public const int MinValue = 1;
    public const int MaxValue = 20;

    public event UnityAction Hit;

    public UnitStats Stats => _stats;
    public Vector2 Position => transform.position;

    private void Awake()
    {
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _animationPlayer = GetComponent<AnimationPlayer>();
    }

    public void Attack(ITargetable target)
    {
        _animationPlayer.PlayAttackAnimation();
    }

    public void TakeHit(int damage)
    {
        Hit?.Invoke();
    }

    public void TurnSide(bool turningLeft)
    {
        _spriteFlipper.TurnSide(turningLeft);   
    }

    public int GetValue()
    {
        // TODO
        return 1;
    }
}