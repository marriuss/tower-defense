using NodeCanvas.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteFader))]
[RequireComponent(typeof(SpriteFlipper))]
[RequireComponent(typeof(AnimationPlayer))]
[RequireComponent(typeof(GraphOwner))]
public abstract class Unit : MonoBehaviour, ITargetable
{
    [SerializeField] private UnitStats _stats;

    private SpriteFader _spriteFader;
    private SpriteFlipper _spriteFlipper;
    private AnimationPlayer _animationPlayer;
    private GraphOwner _graphOwner;
    private Health _health;

    public const int MinValue = 1;
    public const int MaxValue = 20;

    public event UnityAction<Unit> WasHit;
    public event UnityAction<ITargetable> Died;

    public UnitStats Stats => _stats;
    public Vector2 Position => transform.position;

    public int Health => _health.Value;
    public bool Dead => _health.IsMin;

    private void Awake()
    {
        _spriteFader = GetComponent<SpriteFader>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _animationPlayer = GetComponent<AnimationPlayer>();
        _graphOwner = GetComponent<GraphOwner>();
        _health = new Health(Stats.Health);
    }

    public void Spawn()
    {
        _health.IncreaseValue(Stats.Health);

        if (_graphOwner.isPaused)
            _graphOwner.StartBehaviour();

        _spriteFader.FadeIn();
    }

    public void Despawn()
    {
        _graphOwner.PauseBehaviour();
        _spriteFader.FadeOut();
    }

    public void Attack(ITargetable target)
    {
        _animationPlayer.PlayAttackAnimation();
        target.TakeHit(this);
    }

    public void TakeHit(Unit attacker)
    {
        int damage = Stats.RecalculateDamage(attacker.Stats.Damage);
        _health.DecreaseValue(damage);

        if (Dead)
        {
            Die();  
        }
        else
        {
            _animationPlayer.PlayTakeHitAnimation();
            WasHit?.Invoke(attacker);
        }
    }

    public void TurnSide(bool turningLeft)
    {
        _spriteFlipper.TurnSide(turningLeft);   
    }

    public void StartMoving()
    {
        _animationPlayer.PlayMoveAnimation();
    }

    public void Stop()
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

    private void Die()
    {
        Died?.Invoke(this);
        Despawn();
    }
}
