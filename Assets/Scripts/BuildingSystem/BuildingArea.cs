using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Tilemaps;

public class BuildingArea: TilemapLayer
{
    [SerializeField] private TileBase _availableAreaTile;
    
    public bool IsAvailabelArea(Vector3 worldCoords, BuildableItem item)
    {
        ObjectType type = item.Type;
        Vector2Int size = item.Dimenstion;
        Vector3Int baseCoords = _tilemap.WorldToCell(worldCoords);
        List<bool> availableTiles = new List<bool>();
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3Int coords = baseCoords + new Vector3Int(x, y, 0);
                TileBase tileCoords = _tilemap.GetTile(coords);
                availableTiles.Add(tileCoords == _availableAreaTile);
            }
        }
        return availableTiles.All(item=>item);
    }
}
