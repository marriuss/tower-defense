using UnityEngine;

public class Castle : MonoBehaviour
{
    private CastleStats _castleStats;

    public void ApplyProgress(CastleStats castleStats)
    {
        _castleStats = castleStats;
    }
}
