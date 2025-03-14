using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Buildable Item", menuName = "Building/Create Buildable Item")]
public class BuildableItem : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private TileBase _tile;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Vector3 _tileOffset;
    [SerializeField] private Sprite _previewSprite;
    [SerializeField] private Sprite _uiIcon;
    [SerializeField] private Vector2Int _dimenstion;
    [SerializeField] private List<RotationItem> _rotation;
    public string Name => _name;
    public TileBase Tile => _tile;
    public GameObject GameObject => _gameObject;
    public Vector3 TileOffset => _tileOffset;
    // public Sprite PreviewSprite => _previewSprite;
    public Sprite UIIcon => _uiIcon;
    // public Vector2Int Dimenstion => _dimenstion;
    public List<RotationItem> Rotation => _rotation;

    public Vector2Int Dimenstion => _dimenstion;
    public Sprite PreviewSprite => _rotation.Count > 0 ? CurrentRotation.Sprite : _previewSprite;
    
    private int _currentRotationIndex = 0;
    public RotationItem CurrentRotation => _rotation[_currentRotationIndex];

    public void Rotate()
    {
        if (Tile != null) _dimenstion = new Vector2Int(_dimenstion.y, _dimenstion.x);
        else if(Rotation.Count != 0)
        {
            _currentRotationIndex = (_currentRotationIndex + 1) % _rotation.Count;
            _dimenstion = new Vector2Int(_dimenstion.y, _dimenstion.x);
        }
        Debug.Log(_currentRotationIndex);
    }

    public (float X,float Y) GetNewScaleGameobject(Vector3 cellSize)
    {
        float newScaleX, newScaleY;
        if (GameObject != null)
        {
            Vector2 spriteSize = PreviewSprite.bounds.size;
            float aspectRatio = spriteSize.y / spriteSize.x;
            
            newScaleX = (Dimenstion.x * cellSize.x) / spriteSize.x;
            newScaleY = newScaleX * aspectRatio;
        }else
        {
            newScaleX = Dimenstion.x * cellSize.x;
            newScaleY = Dimenstion.y * cellSize.y;
        }
        return (newScaleX, newScaleY);
    }
}

[Serializable]
public class RotationItem
{
    public RotationType Rotation;
    public Sprite Sprite;
}

public enum RotationType
{
    side,
    up,
    down
}

