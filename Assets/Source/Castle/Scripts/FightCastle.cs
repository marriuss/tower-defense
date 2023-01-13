using UnityEngine;
using UnityEngine.Events;

public class FightCastle : MonoBehaviour, ITargetable
{
    private CastleFightStats _castleStats;
    private Health _health;

    public event UnityAction<ITargetable> Died;

    public Vector2 Position => transform.position;

    public int Health => _health.Value;

    private void Awake()
    {
        _health = new Health();
    }

    public void ApplyProgress(CastleFightStats castleStats)
    {
        _castleStats = castleStats;
        _health.IncreaseValue(_castleStats.Health);
    }

    public void TakeHit(Unit attacker)
    {
        
    }
}
