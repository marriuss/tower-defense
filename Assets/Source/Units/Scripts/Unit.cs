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

    public event UnityAction<Unit> Hit; 

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

    public void TakeHit(Unit attacker)
    {
        Hit?.Invoke(attacker);
    }

    public void TurnSide(bool turningLeft)
    {
        _spriteFlipper.TurnSide(turningLeft);   
    }

    public void StartMoving()
    {
        _animationPlayer.PlayMoveAnimation();
    }

    public void StopMoving()
    {
        _animationPlayer.Stop();
    }

    public void MoveTo(Vector2 position)
    {
        transform.position = position;
    }

    public int GetValue()
    {
        // TODO
        return 1;
    }
}