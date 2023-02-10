using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New zone", menuName = "SO/Zone", order = 51)]
public class Zone : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _wavesDelay;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private LevelPalette _palette;

    public string Name => _name;
    public float WavesDelay => _wavesDelay;
    public float SpawnDelay => _spawnDelay;
    public LevelPalette Palette => _palette;
}

[Serializable]
public class LevelPalette
{
    [SerializeField] private TileBase _defaultTile;
    [SerializeField] private List<TileBase> _additionalTiles;
    [SerializeField] private List<Sprite> _backgroundElements;

    public TileBase DefaultTile => _defaultTile;
    public IReadOnlyList<TileBase> BattlefieldTiles => _additionalTiles;
    public IReadOnlyList<Sprite> BackgroundElements => _backgroundElements;
}

