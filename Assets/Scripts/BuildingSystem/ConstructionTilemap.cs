using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConstructionTilemap : TilemapLayer
{
    private Dictionary<Vector3Int, Buildable> _buildables = new(); 
    
    public void Build(Vector3 worldCoords, BuildableItem item)
    {
        GameObject itemObject = null;
        Vector3Int baseCoords = _tilemap.WorldToCell(worldCoords);
        Vector2Int size = item.Dimenstion;
        
        if (!IsEmpty(worldCoords, size)) return;
  
        List<Vector3Int> occupiedTiles = new List<Vector3Int>();
        
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3Int coords = baseCoords + new Vector3Int(x , y, 0);
                occupiedTiles.Add(coords);
                
                var tileChangeData = new TileChangeData(
                    coords, item.Tile, Color.white, Matrix4x4.Translate(item.TileOffset)
                );
                _tilemap.SetTile(tileChangeData, false);
            }
        }
          
        if (item.GameObject != null)
        {
            Vector3 cellSize = _tilemap.cellSize;
            Vector3 position = _tilemap.CellToWorld(baseCoords) 
                                     + new Vector3(size.x/ 2f, size.y / 2f, 0) 
                                     + item.TileOffset
                                     - new Vector3(0,size.y/2f,0);
            itemObject = Instantiate(item.GameObject, position, Quaternion.identity);
            itemObject.GetComponent<SpriteRenderer>().sprite = item.PreviewSprite;
            // var newScale = item.GetNewScaleGameobject(cellSize);
            // itemObject.transform.localScale = new Vector3(newScale.X, newScale.Y, 1);
        }
        
        var buildable = new Buildable(item, baseCoords, _tilemap,  occupiedTiles, itemObject);
        
        foreach (var coords in occupiedTiles)
        {
            _buildables.Add(coords, buildable);
        }
    }

    public bool IsEmpty(Vector3 worldCoords, Vector2Int size)
    {
        Vector3Int baseCoords = _tilemap.WorldToCell(worldCoords);
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3Int coords = baseCoords + new Vector3Int(x, y, 0);
                if (_buildables.ContainsKey(coords) || _tilemap.GetTile(coords) != null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void Destroy(Vector3 worldCoords)
    {
        Vector3Int baseCoords = _tilemap.WorldToCell(worldCoords);

        if (!_buildables.ContainsKey(baseCoords)) return;

        var buildable = _buildables[baseCoords];

        foreach (var coords in buildable.OccupiedTiles)
        {
            _buildables.Remove(coords);
            _tilemap.SetTile(coords, null);
        }

        if (buildable.GameObject != null)
        {
            Destroy(buildable.GameObject);
        }
    }

}
