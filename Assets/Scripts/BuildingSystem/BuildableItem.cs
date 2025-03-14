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
    [SerializeField] private Vector3 _tileOffset;
    [SerializeField] private Sprite _previewSprite;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Sprite _uiIcon;
    [SerializeField] private Vector2Int _defaultDimenstion;
    [SerializeField] private bool OnlyRotateSprite;
    [SerializeField] private List<RotationItem> _rotation;
    public string Name => _name;
    public TileBase Tile => _tile;
    public Vector3 TileOffset => _tileOffset;
    public Sprite UIIcon => _uiIcon;
    public GameObject GameObject => _gameObject;
    public List<RotationItem> Rotation => _rotation;

    private Vector2Int _dimenstion;
    public Vector2Int Dimenstion => _dimenstion;
    public Vector2Int DefaultDimenstion => _defaultDimenstion;
    public Sprite PreviewSprite =>  Rotation.Count > 0 ? CurrentRotation.PreviewSprite : _previewSprite;
    
    public int _currentRotationIndex = 0;
    public RotationItem CurrentRotation => _rotation[_currentRotationIndex];
    

    private RotationType _previousRotation;

    private void OnEnable()
    {
        _currentRotationIndex = 0;
        _dimenstion = DefaultDimenstion;
    }

    public void Rotate(RotationPerformed type)
    {
        if(Rotation.Count != 0)
        {
            _previousRotation = CurrentRotation.Rotation;
            if(type == RotationPerformed.Left) _currentRotationIndex = (_currentRotationIndex + 1) % Rotation.Count;
            else if(type == RotationPerformed.Right) _currentRotationIndex = (_currentRotationIndex - 1 + Rotation.Count) % Rotation.Count;
        }

        if (CanChangeDimension())
        {
            _dimenstion = new Vector2Int(_dimenstion.y, _dimenstion.x);
        }
    }

    public bool CanChangeDimension()
    {
        if (OnlyRotateSprite) return false;
        Debug.Log(_previousRotation+" "+CurrentRotation.Rotation);
        bool wasVertical = _previousRotation == RotationType.up || _previousRotation == RotationType.down;
        bool isCurrentSide = CurrentRotation.Rotation == RotationType.side;
        Debug.Log(wasVertical+" "+isCurrentSide+""+!OnlyRotateSprite);
        bool y = wasVertical && isCurrentSide;
        bool wasHorizontal = _previousRotation == RotationType.side;
        bool isCurrentVertical = CurrentRotation.Rotation != RotationType.side;
        bool x = wasHorizontal && isCurrentVertical;
        return x || y;
        
        return wasVertical && isCurrentSide && !OnlyRotateSprite;
        
        // // 2. Jika OnlyRotateSprite = false, dimensi hanya boleh berubah saat rotasi berubah tipe (vertical <-> horizontal)
        //
        //     bool wasVertical = _previousRotation == RotationType.up || _previousRotation == RotationType.down;
        //     bool isCurrentVertical = CurrentRotation.Rotation == RotationType.up || CurrentRotation.Rotation == RotationType.down;
        //     return wasVertical != isCurrentVertical; // true hanya jika berbeda tipe rotasi
        //
        //     bool wasHorizontal = _previousRotation == RotationType.side;
        //     bool isCurrentVertical = CurrentRotation.Rotation == RotationType.up || CurrentRotation.Rotation == RotationType.down;
        //     return wasHorizontal && isCurrentVertical;
    }
    
    public (float X,float Y) GetNewScaleGameobject(Vector3 cellSize)
    {
        float newScaleX, newScaleY;
        if (CurrentRotation != null)
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
    public Sprite PreviewSprite;
    public bool Flip;

}

public enum RotationType
{
    side,
    up,
    down
}

public enum RotationPerformed
{
    Left, Right
}
