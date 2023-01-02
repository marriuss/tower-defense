using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New zone", menuName = "SO/Zone", order = 51)]
public class Zone : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _wavesDelay;
    [SerializeField] private float _spawnDelay;

    public string Name => _name;
    public float WavesDelay => _wavesDelay;
    public float SpawnDelay => _spawnDelay;
}
