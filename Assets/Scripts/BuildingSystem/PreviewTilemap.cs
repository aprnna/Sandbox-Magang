using UnityEngine;

public class PreviewTilemap : TilemapLayer
{
    [SerializeField] private SpriteRenderer _previewRenderer;

    public void ShowPreview(BuildableItem item, Vector3 worldCoords, bool isValid)
    {
        Vector2Int size = item.Dimenstion;
        Vector3 cellSize = _tilemap.cellSize;
        Vector3Int coords = _tilemap.WorldToCell(worldCoords);
        Vector3 previewPosition = _tilemap.CellToWorld(coords)
                                  + new Vector3(size.x / 2f, size.y / 2f)
                                  + item.TileOffset;
        
        _previewRenderer.enabled = true;
        _previewRenderer.sprite = item.PreviewSprite;
        _previewRenderer.transform.position = previewPosition; 
        if (item.GameObject != null) _previewRenderer.transform.position -= new Vector3(0, size.y / 2f, 0);
        if (item.Rotation.Count > 0)
        {
            Vector3 newScale = _previewRenderer.transform.localScale;
            newScale.x = item.CurrentRotation.Flip ? -Mathf.Abs(newScale.x):Mathf.Abs(newScale.x);
            _previewRenderer.transform.localScale = newScale;
        }
        // var newScale = item.GetNewScaleGameobject(cellSize);
        // _previewRenderer.transform.localScale = new Vector3(newScale.X, newScale.Y, 1); 
        _previewRenderer.color = isValid ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
    }

    public void ClearPreview()
    {
        _previewRenderer.enabled = false;
    }
}
