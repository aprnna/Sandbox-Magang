using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class TilemapLayer : MonoBehaviour
{
  protected Tilemap _tilemap { get; private set; }
  private void Awake()
  {
    _tilemap = GetComponent<Tilemap>();
  }

  protected void SetGameObjectRotation(GameObject itemObject, BuildableItem item)
  {
    Vector3 newScale = itemObject.transform.localScale;
    newScale.x = item.CurrentRotation.Flip ? -Mathf.Abs(newScale.x) : Mathf.Abs(newScale.x);
    itemObject.transform.localScale = newScale;
  }
}
