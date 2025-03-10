using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConstructionLayer : TilemapLayer
{
    private Dictionary<Vector3Int, Buildable> _buildables = new(); 
    [SerializeField] private Collider2D allowedArea;
    public void Build(Vector3 worldCoords, BuildableItem item)
    {
        GameObject itemObject = null;
        Vector3Int coords = _tilemap.WorldToCell(worldCoords);
        if (!IsValidConstructionArea(worldCoords)) return ;
        if (item != null)
        {
            var tileChangeData = new TileChangeData(
                coords, item.Tile, Color.white, Matrix4x4.Translate(item.TileOffset)
            );
            _tilemap.SetTile(tileChangeData, false); 
        }

        if (item.gameObject != null)
        {
            itemObject = Instantiate(item.gameObject,
                _tilemap.CellToWorld(coords) + _tilemap.cellSize / 2 + item.TileOffset, Quaternion.identity);
        }
        var buildable = new Buildable(item, coords, _tilemap, itemObject);
        _buildables.Add(coords,buildable);
    }

    public void Destroy(Vector3 worldCoords)
    {
        Vector3Int coords = _tilemap.WorldToCell(worldCoords);
        if (!_buildables.ContainsKey(coords)) return;
        var buildable = _buildables[coords] ;
        _buildables.Remove(coords);
        buildable.Destroy();

    }
    public bool IsValidConstructionArea(Vector3 worldCoords)
    {
        if (allowedArea == null) return true; 

        Vector3Int cellCoords = _tilemap.WorldToCell(worldCoords);
        Vector3 cellCenter = _tilemap.GetCellCenterWorld(cellCoords);
        Vector3 halfSize = _tilemap.cellSize / 2;

        Vector3 bottomLeft = cellCenter - halfSize;
        Vector3 topRight = cellCenter + halfSize;

        return allowedArea.OverlapPoint(bottomLeft) && allowedArea.OverlapPoint(topRight);
    }
    public bool IsEmpty(Vector3 worldCoords)
    {
        Vector3Int coords = _tilemap.WorldToCell(worldCoords);
        return !_buildables.ContainsKey(coords) && _tilemap.GetTile(coords) == null;
    }
}
