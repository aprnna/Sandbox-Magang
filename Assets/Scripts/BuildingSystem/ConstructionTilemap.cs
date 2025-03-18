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
      
        if (!IsEmpty(worldCoords, item)) return;

        List<Vector3Int> occupiedTiles = new List<Vector3Int>();
        SetTiles(item, baseCoords, occupiedTiles);
        if (item.GameObject != null) itemObject = InstantiateGameObject(item, baseCoords);
        
        // var newScale = item.GetNewScaleGameobject(cellSize);
        // itemObject.transform.localScale = new Vector3(newScale.X, newScale.Y, 1);
        
        var buildable = new Buildable(item, baseCoords, _tilemap, occupiedTiles, itemObject);
        StoreBuildableItems(buildable);
    }

    private void SetTiles(BuildableItem item, Vector3Int baseCoords,  List<Vector3Int> occupiedTiles)
    {
        Vector2Int size = item.Dimenstion;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3Int coords = baseCoords + new Vector3Int(x, y, 0);
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
    }
    
    private GameObject InstantiateGameObject(BuildableItem item, Vector3Int baseCoords)
    {
        Vector3 position = CalculateObjectPosition(baseCoords, item);
        Transform parent = item.Type == ObjectType.Cosmetic ? _cosmeticGameObject : _functionalGameObject;
        GameObject itemObject = Instantiate(item.GameObject, position, Quaternion.identity, parent);
        itemObject.GetComponent<SpriteRenderer>().sprite = item.PreviewSprite;

        if (item.Rotation.Count > 0)  SetGameObjectRotation(itemObject, item);

        return itemObject;
    }

    private Vector3 CalculateObjectPosition(Vector3Int baseCoords, BuildableItem item)
    {
        Vector2Int size = item.Dimenstion;
        return _tilemap.CellToWorld(baseCoords) + new Vector3(size.x / 2f, size.y / 2f, 0) + item.TileOffset - new Vector3(0, size.y / 2f, 0);
    }

    private void StoreBuildableItems(Buildable buildable)
    {
        List<Vector3Int> occupiedTiles = buildable.OccupiedTiles;
        BuildableItem item = buildable.BuildableType;
  
        foreach (var coords in occupiedTiles)
        {
            if (item.Type == ObjectType.Tail)
            {
                if (!_buildablesTiles.ContainsKey(coords)) 
                    _buildablesTiles.Add(coords, buildable);
            }
            else
            {
                if (!_buildablesGameObject.ContainsKey(coords)) 
                    _buildablesGameObject.Add(coords, buildable);
            }
        }
    }
    public bool IsEmpty(Vector3 worldCoords,BuildableItem item)
    {
        Vector2Int size = item.Dimenstion;
        ObjectType type = item.Type;
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
        bool hasTile = _buildablesTiles.TryGetValue(baseCoords, out Buildable buildableTile);
        bool hasGameObject = _buildablesGameObject.TryGetValue(baseCoords, out Buildable buildableGameObject);

        if (!hasTile && !hasGameObject) return;
        if (hasGameObject)
        {
            foreach (var coords in buildableGameObject.OccupiedTiles)
            {
                _buildablesGameObject.Remove(coords);
            }

            if (buildableGameObject.GameObject != null) Destroy(buildableGameObject.GameObject);
            return;
        }
        foreach (var coords in buildableTile.OccupiedTiles)
        {
            _buildablesTiles.Remove(coords);
            _tilemap.SetTile(coords, null);
        }
    }
}
