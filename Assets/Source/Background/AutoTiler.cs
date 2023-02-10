using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoTiler : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField, Range(0, 1)] private float _additionalTileChance;

    public void FillRect(Rect rect, TileBase defaultTile, IReadOnlyList<TileBase> additionalTiles)
    {
        int tilesCount = additionalTiles.Count;
        bool additionalTilesExist = tilesCount > 0;

        _tilemap.ClearAllTiles();

        Vector2 worldPosition = rect.min;
        Vector3Int gridPosition = _tilemap.WorldToCell(worldPosition);
        int startY = gridPosition.y;
        TileBase tile;

        while (worldPosition.x <= rect.xMax)
        {
            gridPosition.y = startY;

            while (worldPosition.y <= rect.yMax)
            {
                if (additionalTilesExist && CheckIsAdditionalTile())
                {
                    tile = additionalTiles[Random.Range(0, tilesCount)];
                }
                else
                {
                    tile = defaultTile;
                }

                _tilemap.SetTile(gridPosition, tile);
                gridPosition.y += 1;
                worldPosition = _tilemap.CellToWorld(gridPosition);
            }

            gridPosition.x += 1;
            worldPosition = _tilemap.CellToWorld(gridPosition);
        }
    }

    private bool CheckIsAdditionalTile() => Random.Range(0.0f, 1.0f) <= _additionalTileChance;
}
