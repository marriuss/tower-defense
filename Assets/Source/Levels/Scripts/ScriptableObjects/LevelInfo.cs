using UnityEngine;

[CreateAssetMenu(fileName = "New Level Info", menuName = "SO/Level Info", order = 51)]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private int _identifier;
    [SerializeField] private Zone _zone;

    // TODO: waves

    public int Identifier => _identifier;
    public Zone Zone => _zone;
}

public enum Zone
{
    Forest,
    Winter,
    Desert,
    Jungle
}
