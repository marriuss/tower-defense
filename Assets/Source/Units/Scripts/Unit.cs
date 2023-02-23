using NodeCanvas.Framework;
using NodeCanvas.BehaviourTrees;
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
    private BehaviourTreeOwner _btOwner;
    private Health _health;

    private float _lastAttackTime;

    public event Action<ITargetable> WasHit;
    public event Action<ITargetable> Died;

    public ITargetable Target { get; private set; }
    public UnitStats Stats => _stats;
    public Vector2 Position => transform.position;
    public HealthState HealthState { get; private set; }
    public bool TargetInRange => Target == null ? false : Vector2.Distance(Target.Position, Position) <= _stats.AttackRange;

    private void Awake()
    {
        _spriteFader = GetComponent<SpriteFader>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _animationPlayer = GetComponent<AnimationPlayer>();
        _btOwner = GetComponent<BehaviourTreeOwner>();
        _soundsPlayer = GetComponent<SoundsPlayer>();
        _health = new Health(Stats.Health);
        HealthState = new HealthState(_health);
    }

    private void Update()
    {
        if (Target != null)
            _spriteFlipper.TurnSide(!Battlefield.IsLefter(Position, Target.Position));
    }

    public void Spawn()
    {
        _health.IncreaseValue(Stats.Health);
        _spriteFader.FadeIn();

        if (_btOwner.isRunning == false)
            _btOwner.StartBehaviour();

        _animationPlayer.Reset();
        Idle();
    }

    public void SetTarget(ITargetable target) => Target = target;

    public void MoveTowardsTarget()
    {
        if (Target == null)
            return;

        _animationPlayer.PlayMoveAnimation();
        MoveTo(Vector2.MoveTowards(Position, Target.Position, _stats.Speed * Time.deltaTime));
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
            //_soundsPlayer.PlayAttackSound();
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
        _btOwner.StopBehaviour();
        Target = null;
        _spriteFader.FadeOut();
        _animationPlayer.PlayDeathAnimation();
        Died?.Invoke(this);
    }

    private void ApplyDamageToTarget()
    {
        if (TargetInRange && HealthState.IsDead == false)
            Target.TakeHit(this);
    }
}
