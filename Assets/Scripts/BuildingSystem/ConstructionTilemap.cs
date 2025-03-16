using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConstructionTilemap : TilemapLayer
{
    [SerializeField] private Transform _cosmeticGameObject;
    [SerializeField] private Transform _functionalGameObject;
    
    private Dictionary<Vector3Int, Buildable> _buildablesTiles = new();
    private Dictionary<Vector3Int, Buildable> _buildablesGameObject = new();
    
    public void Build(Vector3 worldCoords, BuildableItem item)
    {
        GameObject itemObject = null;
        Vector3Int baseCoords = _tilemap.WorldToCell(worldCoords);
        Vector2Int size = item.Dimenstion;
      
        if (!IsEmpty(worldCoords, item.Type, size)) return;

        List<Vector3Int> occupiedTiles = new List<Vector3Int>();
        
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3Int coords = baseCoords + new Vector3Int(x , y, 0);
                occupiedTiles.Add(coords);
                if (item.Type == ObjectType.Tail)
                {
                    var tileChangeData = new TileChangeData(
                        coords, item.Tile, Color.white, Matrix4x4.Translate(item.TileOffset)
                    );
                    _tilemap.SetTile(tileChangeData, false);
                }
            }
        }
          
        if (item.GameObject != null)
        {
            Vector3 cellSize = _tilemap.cellSize;
            Vector3 position = _tilemap.CellToWorld(baseCoords) 
                                     + new Vector3(size.x/ 2f, size.y / 2f, 0) 
                                     + item.TileOffset
                                     - new Vector3(0,size.y/2f,0);
            Transform parent= item.Type == ObjectType.Cosmetic ? _cosmeticGameObject : _functionalGameObject;
            itemObject =  Instantiate(item.GameObject, position, Quaternion.identity, parent);
            itemObject.GetComponent<SpriteRenderer>().sprite = item.PreviewSprite;
            if (item.Rotation.Count > 0)
            {
                Vector3 newScale = itemObject.transform.localScale;
                newScale.x = item.CurrentRotation.Flip ?  -Mathf.Abs(newScale.x) : Mathf.Abs(newScale.x);
                itemObject.transform.localScale = newScale;
            }
      
            // var newScale = item.GetNewScaleGameobject(cellSize);
            // itemObject.transform.localScale = new Vector3(newScale.X, newScale.Y, 1);
        }
        
        var buildable = new Buildable(item, baseCoords, _tilemap,  occupiedTiles, itemObject);
        
        foreach (var coords in occupiedTiles)
        {
            if (item.Type == ObjectType.Tail) _buildablesTiles.Add(coords, buildable);
            else _buildablesGameObject.Add(coords,buildable);
        }
    }

    public bool IsEmpty(Vector3 worldCoords,ObjectType type,Vector2Int size)
    {
        Vector3Int baseCoords = _tilemap.WorldToCell(worldCoords);
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3Int coords = baseCoords + new Vector3Int(x, y, 0);
                var occupied = type == ObjectType.Tail
                    ? _buildablesTiles.ContainsKey(coords)
                    : _buildablesGameObject.ContainsKey(coords);
                if (occupied) return false;
            }
        }
        return true;
    }

    public void Destroy(Vector3 worldCoords)
    {
        Vector3Int baseCoords = _tilemap.WorldToCell(worldCoords);

        if (!_buildablesTiles.ContainsKey(baseCoords)) return;

        var buildable = _buildablesTiles[baseCoords];

        foreach (var coords in buildable.OccupiedTiles)
        {
            _buildablesTiles.Remove(coords);
            _tilemap.SetTile(coords, null);
        }

        if (buildable.GameObject != null)
        {
            Destroy(buildable.GameObject);
        }
    }

}
