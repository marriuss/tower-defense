using NodeCanvas.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(SoundsPlayer))]
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
    private SoundsPlayer _soundsPlayer;
    private GraphOwner _graphOwner;
    private Health _health;
    private ITargetable _target;
    private float _lastAttackTime;

    public event Action<ITargetable> WasHit;
    public event Action<ITargetable> Died;

    public UnitStats Stats => _stats;
    public Vector2 Position => transform.position;
    public HealthState HealthState { get; private set; }
    public bool TargetInRange => _target == null ? false : Vector2.Distance(_target.Position, Position) <= _stats.AttackRange;

    private void Awake()
    {
        _spriteFader = GetComponent<SpriteFader>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _animationPlayer = GetComponent<AnimationPlayer>();
        _graphOwner = GetComponent<GraphOwner>();
        _soundsPlayer = GetComponent<SoundsPlayer>();
        _health = new Health(Stats.Health);
        HealthState = new HealthState(_health);
    }

    private void Update()
    {
        if (_target != null)
            _spriteFlipper.TurnSide(!Battlefield.IsLefter(Position, _target.Position));
    }

    public void Spawn()
    {
        _health.IncreaseValue(Stats.Health);
        _spriteFader.FadeIn();

        if (_graphOwner.isPaused)
            _graphOwner.StartBehaviour();

        _animationPlayer.Reset();
        Idle();
    }

    public void SetTarget(ITargetable target) => _target = target;

    public void MoveTowardsTarget()
    {
        if (_target == null)
            return;

        _animationPlayer.PlayMoveAnimation();
        MoveTo(Vector2.MoveTowards(Position, _target.Position, _stats.Speed * Time.deltaTime));
    } 

    public void AttackTarget()
    {
        if (TargetInRange == false)
            return;

        float time = Time.time;

        if (_lastAttackTime + _stats.AttackDelay <= time)
        {
            _lastAttackTime = time;
            _animationPlayer.PlayAttackAnimation();
            _soundsPlayer.PlayAttackSound();
        }
    }

    public void TakeHit(Unit attacker)
    {
        int damage = Stats.RecalculateDamage(attacker.Stats.Damage);
        _health.DecreaseValue(damage);

        if (HealthState.IsDead)
        {
            Die();  
        }
        else
        {
            //_animationPlayer.PlayTakeHitAnimation();
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

    public void Idle()
    {
        _animationPlayer.PlayIdleAnimation();
    }

    public void MoveTo(Vector2 position)
    {
        transform.position = position;
    }

    private void Die()
    {
        _target = null;
        _animationPlayer.PlayDeathAnimation();
        _graphOwner.PauseBehaviour();
        _spriteFader.FadeOut();
        Died?.Invoke(this);
    }

    private void ApplyDamageToTarget()
    {
        if (TargetInRange && HealthState.IsDead == false)
            _target.TakeHit(this);
    }
}
