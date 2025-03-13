using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Buildable
{
    [SerializeField] private Tilemap _parentTilemap;
    [SerializeField] private BuildableItem _buildableType;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Vector3Int _coordinates;
    [SerializeField] private List<Vector3Int> _occupiedTiles;

    public Tilemap ParentTilemap => _parentTilemap;
    public BuildableItem BuildableType => _buildableType;
    public GameObject GameObject => _gameObject;
    public Vector3Int Coordinates => _coordinates;
    public List<Vector3Int> OccupiedTiles => _occupiedTiles;
    public Buildable(BuildableItem type, Vector3Int coords, Tilemap tilemap, List<Vector3Int> occupiedTiles, GameObject gameObject = null)
    {
        _parentTilemap = tilemap;
        _buildableType = type;
        _coordinates = coords;
        _gameObject = gameObject;
        _occupiedTiles = occupiedTiles;
    }

    public void Destroy()
    {
        if (GameObject != null)
        {
            Object.Destroy(GameObject);
        }
        ParentTilemap.SetTile(Coordinates, null);
    }
}
