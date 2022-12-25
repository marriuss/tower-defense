using UnityEngine;

[CreateAssetMenu(fileName = "New Level Info", menuName = "SO/Level Info", order = 51)]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private int _identifier;
    [SerializeField] private Zone _zone;
    [SerializeField] private Wave[] _waves;

    public int Identifier => _identifier;
    public Zone Zone => _zone;
    public Wave GetWave(int index) => _waves[index];
}

public enum Zone
{
    Forest,
    Winter,
    Desert,
    Jungle
}
