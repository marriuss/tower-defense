using UnityEngine;

public class Castle : MonoBehaviour, ITargetable
{
    private CastleStats _castleStats;

    public Vector2 Position => transform.position;

    public void ApplyProgress(CastleStats castleStats)
    {
        _castleStats = castleStats;
    }
}
