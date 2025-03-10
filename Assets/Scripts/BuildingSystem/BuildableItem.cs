using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Buildable Item", menuName = "Building/Create Buildable Item")]
public class BuildableItem : ScriptableObject
{
    [field:SerializeField]
    public string Name { get; private set; }
    
    [field:SerializeField]
    public TileBase Tile { get; private set; }
    [field:SerializeField]
    public GameObject gameObject { get; private set; }
    
    [field:SerializeField]
    public Vector3 TileOffset { get; private set; }
    
    [field:SerializeField]
    public Sprite PreviewSprite { get; private set; }
    
    [field:SerializeField]
    public Sprite UIIcon { get; private set; }
}
